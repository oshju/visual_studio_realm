using System;
using System.Collections.Generic;
using System.Linq;
using Realms;

namespace Ejerrealm1.models.respositories
{
    public class RespositoryRealm
    {
        private Realm conexionrealm;
        Transaction transaction;

        public RespositoryRealm()
        {
            //CREAMOS EL OBJETO QUE NOS PERMITIRA CONECTARNOS 
            //CON REALM EN CADA DISPOSITIVO 
            this.conexionrealm = Realm.GetInstance();
        }

        //METODO PARA DEVOLVER TODOS LOS OBJETOS PERSONAJES 
        public List<Departamento> GetPersonajes()
        {
            List<Departamento> lista = this.conexionrealm.All<Departamento>().ToList();
            return lista;
        }

        public Departamento BuscarPersonaje(int idpersonaje)
        {
            //RECUPERAMOS TODOS LOS PERSONAJES 
            List<Departamento> lista = this.GetPersonajes();
            //BUSCAMOS UN PERSONAJE EN CONCRETO 
            Departamento personaje = lista.FirstOrDefault(z => z.dept_no == idpersonaje);
            return personaje;
        }

        public int GetMaximoIdPersonaje()
        {
            //RECUPERAMOS TODOS LOS PERSONAJES 
            List<Departamento> lista = this.GetPersonajes();
            return lista.Count + 1;
        }

        //METODO PARA INSERTAR EN REALM.   
        public void InsertarPersonaje(Departamento departamento)
        {
            transaction = conexionrealm.BeginWrite();
            var entry = conexionrealm.Add(departamento);
            transaction.Commit();
            //this.conexionrealm.Write(() => 
            //{ 
            //    //CREAMOS UN NUEVO PERSONAJE PARA INSERTAR 
            //    //EN EL METODO WRITE 
            //    Personaje newpersonaje = new Personaje(); 
            //    newpersonaje.IdPersonaje = this.GetMaximoIdPersonaje(); 
            //    newpersonaje.Nombre = personaje.Nombre; 
            //    newpersonaje.Serie = personaje.Serie; 
            //}); 
        }

        //METODO PARA MODIFICAR EN REALM.   
        public void ModificarPersonaje(Departamento personaje)
        {
            //BUSCAMOS UN PERSONAJE EN CONCRETO 
            Departamento existepersonaje = this.BuscarPersonaje(personaje.dept_no);
            //UTILIZAMOS TRANSACCIONES PARA MODIFICAR EL PERSONAJE 
            using (var trans = this.conexionrealm.BeginWrite())
            {
                existepersonaje.dept_no = personaje.dept_no;
                existepersonaje.dept_name = personaje.dept_name;
                existepersonaje.dept_loc = personaje.dept_loc;
                trans.Commit();
            }
        }

        public void EliminarPersonaje(int dept_no)
        {
            //BUSCAMOS EL PERSONAJE 
            Departamento personaje = this.BuscarPersonaje(dept_no);

            if (personaje != null)
            {
                using (var trans = this.conexionrealm.BeginWrite())
                {
                    this.conexionrealm.Remove(personaje);
                    trans.Commit();
                }
            }
        }
    }
}

