using GlobalSolution.Models;
using GlobalSolution.Service.dto;
using GlobalSolution.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GlobalSolution.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoService _medicoService;

        public MedicoController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        public async Task<ActionResult> Create()
        {
            var viewModel = new MedicoViewModel
            {

            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(MedicoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var medicoDTO = new MedicoCadastroDTO
                    {
                        NomeMedico = viewModel.NomeMedico,
                        Especialidade = viewModel.Especialidade,
                        Crm = viewModel.Crm,
                        NomeHospital = viewModel.NomeHospital,
                        TelefoneHospital = viewModel.TelefoneHospital,
                        Latitude = viewModel.Latitude,
                        Longitude = viewModel.Longitude
                    };

                    await _medicoService.CreateMedicoAsync(medicoDTO);
                    TempData["SuccessMessage"] = "Médico criado com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Erro ao criar médico: {ex.Message}";
                    return View(viewModel);
                }
            }

            // Carregar dados para ViewModel se necessário
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(long id, MedicoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var medicoDTO = new MedicoCadastroDTO
                    {
                        NomeMedico = viewModel.NomeMedico,
                        Especialidade = viewModel.Especialidade,
                        Crm = viewModel.Crm,
                        NomeHospital = viewModel.NomeHospital,
                        TelefoneHospital = viewModel.TelefoneHospital,
                        Latitude = viewModel.Latitude,
                        Longitude = viewModel.Longitude
                    };

                    await _medicoService.UpdateMedicoAsync(id, medicoDTO);
                    TempData["SuccessMessage"] = "Médico atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Erro ao atualizar médico: {ex.Message}";
                    return View(viewModel);
                }
            }

            // Carregar dados para ViewModel se necessário
            return View(viewModel);
        }

        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _medicoService.DeleteMedicoAsync(id);
                TempData["SuccessMessage"] = "Médico excluído com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erro ao excluir médico: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Index()
        {
            var medicos = await _medicoService.GetAllMedicosAsync();
            return View(medicos);
        }
    }
}
