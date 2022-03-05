using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Instituciones
{
    public class GridModel : PageModel
    {
        private readonly IInstitutoService instituto;

        public GridModel(IInstitutoService instituto)
        {
            this.instituto = instituto;
        }
        public IEnumerable<InstitucionEntity> GridList { get; set; } = new List<InstitucionEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await instituto.GET();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {

            try
            {
                var result = await instituto.DELETE( new()
                { Id_Institucion = id });

                if (result.CodError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El registro fue eliminado satisfactoriamente";

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
   }
