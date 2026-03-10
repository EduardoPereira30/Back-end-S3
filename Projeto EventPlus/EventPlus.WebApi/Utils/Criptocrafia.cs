namespace EventPlus.WebApi.Utils
{
    public static class Criptocrafia
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);

        }

        public static bool CompararSenha(string senhaIformada,string senhaBanco) 
        {
        return BCrypt.Net.BCrypt.Verify(senhaIformada, senhaBanco);

        }

    }
}
