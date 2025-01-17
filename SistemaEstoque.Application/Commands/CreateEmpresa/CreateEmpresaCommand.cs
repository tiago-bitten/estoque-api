﻿using MediatR;
using SistemaEstoque.Domain.Enums;

namespace SistemaEstoque.Application.Commands.CreateEmpresa
{
    public class CreateEmpresaCommand : IRequest<CreateEmpresaResponse>
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public ETipoEmpresa TipoEmpresa { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int ProprietarioId { get; set; }
    }
}
