using ENT;
using Servicio;
using System;
using MostrarApi.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MostrarApi.Models.Utils;

namespace MostrarApi.Models
{
    public class PersonasVM : INotifyPropertyChanged
    {
        private ObservableCollection<Personas> listadoPersonas;
        private Personas personaSeleccionada;
        private DelegateCommand crearCommand;
        private DelegateCommand eliminarCommand;

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

        public DelegateCommand CrearCommand
        {
            get { return crearCommand; }
        }

        public DelegateCommand EliminarCommand
        {
            get
            {
                return eliminarCommand;
            }
        }
        public PersonasVM()
        {
            mostrarListadoPersonas();
            eliminarCommand = new DelegateCommand(eliminarPersonaExecute, canExecuteEliminar);
            crearCommand = new DelegateCommand(crearExecute);
        }

        public async void crearExecute()
        {
            await Shell.Current.GoToAsync("///CrearPersona");
        }

        /// <summary>
        /// Función que ejecuta la eliminación de la persona seleccionada, pidiendo confirmación al usuario.
        /// Pre: Nada
        /// Post: Si el usuario confirma la eliminación, se elimina la persona de la base de datos.
        /// </summary>
        public async void eliminarPersonaExecute()
        {
            bool eliminar = await Application.Current.MainPage.DisplayAlert("Eliminar", "¿Seguro que quieres eliminar a esta persona?", "Aceptar", "Cancelar");
            if (eliminar)
            {
                PersonaSeleccionada = null;
                mostrarListadoPersonas();
                await Application.Current.MainPage.DisplayAlert("Éxito", "Persona eliminada correctamente.", "Cerrar");
            }
        }

        /// <summary>
        /// Función que determina si el botón de eliminar debe estar habilitado o no.
        /// Pre: Nada
        /// Post: Retorna true si hay una persona seleccionada, habilitando el botón de eliminar.
        /// </summary>
        /// <returns>True si hay una persona seleccionada, false de lo contrario.</returns>
        public bool canExecuteEliminar()
        {
            bool canExecute = false;
            if (PersonaSeleccionada != null)
            {
                canExecute = true;
            }
            return canExecute;
        }

        private async void mostrarListadoPersonas()
        {
            List<Personas> lista = new List<Personas>();
            lista = await ManejadoraAPI.getListadoPersonasAPI();
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
