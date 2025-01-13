namespace ENT
{
    public class Personas
    {
        private int _id;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _direccion;
        private string _foto;
        private DateTime _fechaNac;
        private int _idDepart;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public DateTime FechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        public int IdDepart
        {
            get { return _idDepart; }
            set { _idDepart = value; }
        }


        public Personas() { }
        public Personas(int id, string nombre, string apellido, string telefono, string direccion, string foto, DateTime fechaNac, int idDepart)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellidos = apellido;
            this._telefono = telefono;
            this._direccion = direccion;
            this._foto = foto;
            this._fechaNac = fechaNac;
            this._idDepart = idDepart;
        }
    }
}
