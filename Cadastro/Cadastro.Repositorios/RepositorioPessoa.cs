namespace Cadastro.Repositorios
{
  public class RepositorioPessoa
    {
      private static RepositorioPessoa instanciaDoRepositorio = null;
      private RepositorioFisica rFisica;

      private RepositorioPessoa()
      {
          rFisica = RepositorioFisica.Instancia();
      }
      public static RepositorioPessoa Instancia()
      {
          if (instanciaDoRepositorio == null)
              instanciaDoRepositorio = new RepositorioPessoa();
          return instanciaDoRepositorio;
      }

    }
}
