﻿namespace SistemaEstoque.Application.DTOs;

public class PermissaoInsumoDTO
{
    public int Id { get; set; }
    public bool Visualizar { get; set; }
    public bool Criar { get; set; }
    public bool Editar { get; set; }
    public bool Excluir { get; set; }
}