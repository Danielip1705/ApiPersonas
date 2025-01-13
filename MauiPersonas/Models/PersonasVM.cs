using ENT;
using MauiPersonas.Vista;
using Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiPersonas.Models
{
    public class PersonasVM : INotifyPropertyChanged
    {
        private ObservableCollection<Personas> listadoPersonas;
        private Personas personaSeleccionada;

        public ObservableCollection<Personas> ListadoPersonas
        {
            get { return listadoPersonas; }
            set
            {
                listadoPersonas = value;
                NotifyPropertyChange("ListadoPersonas");
            }
        }

        public Personas PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChange("PersonaSeleccionada");
            }
        }

        public PersonasVM()
        {
            mostrarListadoPersonas();
        }


        private void mostrarListadoPersonas()
        {
            List<Personas> lista = new List<Personas>();
            lista = ManejadoraAPI.getListadoPersonasAPI().Result;
            ListadoPersonas = new ObservableCollection<Personas>(lista);
            NotifyPropertyChange("ListadoPersonas");
        }
        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
