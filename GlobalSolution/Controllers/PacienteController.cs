using GlobalSolution.Models;
using GlobalSolution.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalSolution.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public async Task<ActionResult> Create()
        {
            var viewModel = new PacienteCadastroViewModel
            {
                Estados = await _pacienteService.GetEstadosAsync(),
                Cidades = await _pacienteService.GetCidadesAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PacienteCadastroViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    var pacienteDTO = new PacienteCadastroDTO
                    {
                        Nome = viewModel.Paciente.Nome,
                        DataNascimento = viewModel.Paciente.DataNascimento,
                        Sexo = viewModel.Paciente.Sexo,
                        Rua = viewModel.Endereco.Rua,
                        Numero = viewModel.Endereco.Numero,
                        Cep = viewModel.Endereco.Cep,
                        NomeCidade = viewModel.NomeCidade,
                        NomeEstado = viewModel.NomeEstado
                    };

                    await _pacienteService.CreatePacienteAsync(pacienteDTO);
                    TempData["SuccessMessage"] = "Paciente criado com sucesso!";

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Erro ao criar paciente: {ex.Message}";
                }

            }

            viewModel.Estados = await _pacienteService.GetEstadosAsync();
            viewModel.Cidades = await _pacienteService.GetCidadesAsync();
            return View(viewModel);
        }

        public async Task<ActionResult> Edit(long id)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            var viewModel = new PacienteCadastroViewModel
            {
                Paciente = paciente,
                Estados = await _pacienteService.GetEstadosAsync(),
                Cidades = await _pacienteService.GetCidadesAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(long id, PacienteCadastroViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _pacienteService.UpdatePacienteAsync(id, viewModel.ToPacienteCadastroDTO());
                    TempData["SuccessMessage"] = "Paciente atualizado com sucesso!";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Erro ao atualizar paciente: {ex.Message}";
                }

                return RedirectToAction("Index");
            }

            viewModel.Estados = await _pacienteService.GetEstadosAsync();
            viewModel.Cidades = await _pacienteService.GetCidadesAsync();
            return View(viewModel);
        }

        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _pacienteService.DeletePacienteAsync(id);
                TempData["SuccessMessage"] = "Paciente excluído com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir paciente: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Index()
        {
            var pacientes = await _pacienteService.GetAllPacientesAsync();
            return View(pacientes);
        }
    }


}
