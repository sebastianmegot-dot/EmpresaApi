Imports EmpresaApi.Models

Namespace Services
    Public Interface IClienteService
        Function ObtenerTodosAsync() As Task(Of List(Of Cliente))
        Function ObtenerPorIdAsync(id As Integer) As Task(Of Cliente)
        Function CrearAsync(cliente As Cliente) As Task(Of Cliente)
        Function ActualizarAsync(id As Integer, datos As Cliente) As Task(Of Boolean)
        Function EliminarAsync(id As Integer) As Task(Of Boolean)
    End Interface
End Namespace