using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ejerrealm1.models;
using Ejerrealm1.models.respositories;

namespace Ejerrealm1.viewmodels
{
    public class PersonajesViewModel : ViewModelBase
    {
        private RespositoryRealm repo;

        public PersonajesViewModel()
        {
            this.repo = new RespositoryRealm();
            List<Departamento> lista = this.repo.GetPersonajes();
            this.Personajes = new ObservableCollection<Departamento>(lista);
        }


        private ObservableCollection<Departamento> _Personajes;
        public ObservableCollection<Departamento> Personajes
        {
            get { return this._Personajes; }
            set
            {
                this._Personajes = value;
                OnPropertyChanged("Personajes");
            }
        }
    }
}
