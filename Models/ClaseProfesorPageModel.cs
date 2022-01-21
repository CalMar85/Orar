using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Orar.Data;

namespace Orar.Models
{
    public class ClaseProfesorPageModel : PageModel
    {
        public List<ClasaAsignata> ClasaAsignataList;
        public void PopulateClasaAsignata(OrarContext context,
        Profesor profesor)
        {
            var allClase = context.Clasa;
            var Claseprofesor = new HashSet<int>(
            profesor.ClaseProfesor.Select(c => c.ClasaID)); //
            ClasaAsignataList = new List<ClasaAsignata>();
            foreach (var cat in allClase)
            {
                ClasaAsignataList.Add(new ClasaAsignata
                {
                    ClasaID = cat.ID,
                    NumeClasa = cat.NumeClasa,
                    Asignata = Claseprofesor.Contains(cat.ID)
                });
            }
        }
        public void UpdateClaseProfesor(OrarContext context,
        string[] selectedClase, Profesor profesorToUpdate)
        {
            if (selectedClase == null)
            {
                profesorToUpdate.ClaseProfesor = new List<ClasaProfesor>();
                return;
            }
            var selectedClaseHS = new HashSet<string>(selectedClase);
            var Claseprofesor = new HashSet<int>
            (profesorToUpdate.ClaseProfesor.Select(c => c.Clasa.ID));
            foreach (var cat in context.Clasa)
            {
                if (selectedClaseHS.Contains(cat.ID.ToString()))
                {
                    if (!Claseprofesor.Contains(cat.ID))
                    {
                        profesorToUpdate.ClaseProfesor.Add(
                        new ClasaProfesor
                        {
                            ProfesorID = profesorToUpdate.ID,
                            ClasaID = cat.ID
                        });
                    }
                }
                else
                {
                    if (Claseprofesor.Contains(cat.ID))
                    {
                        ClasaProfesor courseToRemove
                        = profesorToUpdate
                        .ClaseProfesor
                        .SingleOrDefault(i => i.ClasaID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }

        }
    }

}   

