using DataAccess.Crud;
using DTO.Models;
using System.Collections.Generic;

namespace App_Logic.Admins
{
    public class AdminMascotas
    {
        public List<Mascota> GetAllMascotas()
        {
            MascotaCrud mascotaCrud = new MascotaCrud();

            return mascotaCrud.RetrieveAll<Mascota>();
        }

        public async void CreateMascota(Mascota mascota)
        {
            MascotaCrud mascotaCrud = new MascotaCrud();

            mascotaCrud.Create(mascota);
        }

        public Mascota GetMascotaById(int id)
        {
            MascotaCrud mCrud = new MascotaCrud();

            return mCrud.RetrieveById<Mascota>(id);
        }

        public List<Mascota> GetMascotaByPhrase(int idDuenno)
        {
            MascotaCrud mCrud = new MascotaCrud();
            return mCrud.RetrieveBySearchPhrase<Mascota>(idDuenno);
        }

        public void DeleteMascotaById(int id)
        {
            MascotaCrud mCrud = new MascotaCrud();
            mCrud.Delete(new Mascota { Id = id });
        }

        public void UpdateMascota(Mascota mascota)
        {
            MascotaCrud mCrud = new MascotaCrud();
            mCrud.Update(mascota);
        }
    }
}
