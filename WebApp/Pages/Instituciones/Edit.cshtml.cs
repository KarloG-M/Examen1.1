using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Instituciones
{
    public class EditModel : PageModel
    {
        private readonly IInstitutoService instituto;

        public EditModel(IInstitutoService instituto)
        {
            this.instituto = instituto;
        }

        public void OnGet()
        {

        }
    }
}
