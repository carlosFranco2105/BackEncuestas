using Entities.Models;

namespace Logic.IRepositories
{
    public interface INombreEncuestaRepository
    {
        List<NombreEncuesta> GetNombreEncuestas();


        //decimal? DesdeIntranet { get; set; }
        //decimal? DesdeWeb { get; set; }
        //string? FechaHora { get; set; }
        //long IdEncuesta { get; set; }
        //NombreEncuesta IdEncuestaNavigation { get; set; }
        //long IdRespuesta { get; set; }
        //string? Plataforma { get; set; }
    }
}