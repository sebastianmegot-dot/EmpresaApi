Imports EmpresaApi.Models

Namespace Repositories
    Public Interface IClienteRepository
        Function ObtenerTodosAsync() As Task(Of List(Of Cliente))
        Function ObtenerPorIdAsync(id As Integer) As Task(Of Cliente)
        Function AgregarAsync(cliente As Cliente) As Task(Of Cliente)
        Function ActualizarAsync(cliente As Cliente) As Task
        Function EliminarAsync(cliente As Cliente) As Task
        Function ExisteEmailAsync(email As String, Optional excluirId As Integer = 0) As Task(Of Boolean)
    End Interface
End Namespace