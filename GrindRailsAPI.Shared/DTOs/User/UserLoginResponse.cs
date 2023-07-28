﻿using System.Text.Json.Serialization;

namespace GrindRailsAPI.Shared.DTOs.User
{
    public class UserLoginResponse
    {
        public bool Sucesso => Erros.Count == 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AccessToken { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RefreshToken { get; private set; }

        public List<string> Erros { get; private set; }

        public UserLoginResponse() =>
            Erros = new List<string>();

        public UserLoginResponse(bool sucesso, string accessToken, string refreshToken) : this()
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public void AdicionarErro(string erro) =>
            Erros.Add(erro);

        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
