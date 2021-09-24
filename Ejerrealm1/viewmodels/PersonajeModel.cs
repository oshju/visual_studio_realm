using System;
using Ejerrealm1.models;
using Ejerrealm1.models.respositories;
using Xamarin.Forms;

namespace Ejerrealm1.viewmodels
{
    public class PersonajeModel : ViewModelBase
    {
        RespositoryRealm repo;

        public PersonajeModel()
        {
            this.repo = new RespositoryRealm();
            this.Personaje = new Departamento();
        }

        //PROPIEDAD PARA REALIZAR LOS BINDINGS SOBRE LAS VISTAS 
        private Departamento _Personaje;
        public Departamento Personaje
        {
            get { return this._Personaje; }
            set
            {
                this._Personaje = value;
                OnPropertyChanged("Personaje");
            }
        }

        //PROPIEDAD PARA MOSTRAR LOS RESULTADOS DE LAS ACCIONES 
        private String _Mensaje;
        public String Mensaje
        {
            get { return this._Mensaje; }
            set
            {
                this._Mensaje = value;
                OnPropertyChanged("Mensaje");
            }
        }

        public Command InsertarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.InsertarPersonaje(this.Personaje);
                    this.Mensaje = "Dato insertado";
                });
            }
        }

        public Command ModificarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.ModificarPersonaje(this.Personaje);
                    this.Mensaje = "Dato Modificado";
                });
            }
        }

        public Command EliminarDato
        {
            get
            {
                return new Command(() => {
                    this.repo.EliminarPersonaje(this.Personaje.dept_no);
                    this.Mensaje = "Dato Eliminado";
                });
            }
        }
    }
}
