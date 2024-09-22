﻿using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Domain.Interfaces.Services
{
    public interface IAmbienteUsuario
    {
        Task<Usuario> GetUsuarioAsync();
        int GetUsuarioId();
        
        Task<Empresa> GetTenantAsync();
        int GetTenantId();

        bool Bloqueado();
        bool Autenticado();
        
        Task<(Usuario usuario, int tenantId)> GetUsuarioAndTenantAsync();
    }
}