Imports Microsoft.EntityFrameworkCore
Imports EmpresaApi.Data
Imports EmpresaApi.Models

Namespace Repositories
    Public Class ClienteRepository
        Implements IClienteRepository

        Private ReadOnly _context As EmpresaDbContext

        Public Sub New(context As EmpresaDbContext)
            _context = context
        End Sub

        Public Async Function ObtenerTodosAsync() As Task(Of List(Of Cliente)) _
            Implements IClienteRepository.ObtenerTodosAsync
            Return Await _context.Clientes.AsNoTracking().ToListAsync()
        End Function

        Public Async Function ObtenerPorIdAsync(id As Integer) As Task(Of Cliente) _
            Implements IClienteRepository.ObtenerPorIdAsync
            Return Await _context.Clientes.FindAsync(id)
        End Function

        Public Async Function AgregarAsync(cliente As Cliente) As Task(Of Cliente) _
            Implements IClienteRepository.AgregarAsync
            _context.Clientes.Add(cliente)
            Await _context.SaveChangesAsync()
            Return cliente
        End Function

        Public Async Function ActualizarAsync(cliente As Cliente) As Task _
            Implements IClienteRepository.ActualizarAsync
            _context.Clientes.Update(cliente)
            Await _context.SaveChangesAsync()
        End Function

        Public Async Function EliminarAsync(cliente As Cliente) As Task _
            Implements IClienteRepository.EliminarAsync
            _context.Clientes.Remove(cliente)
            Await _context.SaveChangesAsync()
        End Function

        Public Async Function ExisteEmailAsync(email As String, Optional excluirId As Integer = 0) As Task(Of Boolean) _
            Implements IClienteRepository.ExisteEmailAsync
            Return Await _context.Clientes.AnyAsync(Function(c) c.Email = email AndAlso c.Id <> excluirId)
        End Function
    End Class
End Namespace