namespace DigitalMenu.Models
{
    public class PaginacionViewModel
    {
        public int Pagina { get; set; } = 1;
        private int recorsPorPagina = 10;
        private readonly int cantidadMaximaRecordsPorPagina = 10;

        public int RecorsPorPagina
        {
            get
            {
                return recorsPorPagina;
            }
            set
            {
                recorsPorPagina = (value > cantidadMaximaRecordsPorPagina) ?
                    cantidadMaximaRecordsPorPagina : value;
            }
        }

        public int RecorsASaltar => recorsPorPagina * (Pagina - 1);
    }
}
