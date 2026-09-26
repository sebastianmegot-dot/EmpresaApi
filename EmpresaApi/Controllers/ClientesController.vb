Imports Microsoft.AspNetCore.Mvc
Imports EmpresaApi.Models
Imports EmpresaApi.Services

Namespace Controllers
    <ApiController>
    <Route("api/[controller]")>
    Public Class ClientesController
        Inherits ControllerBase

        Private ReadOnly _service As IClienteService

        Public Sub New(service As IClienteService)
            _service = service
        End Sub

        <HttpGet>
        Public Async Function GetAll() As Task(Of IActionResult)
            Return Ok(Await _service.ObtenerTodosAsync())
        End Function

        <HttpGet("{id:int}")>
        Public Async Function GetById(id As Integer) As Task(Of IActionResult)
            Try
                Dim cliente = Await _service.ObtenerPorIdAsync(id)
                If cliente Is Nothing Then Return NotFound(New With {.mensaje = $"No existe el cliente con Id {id}."})
                Return Ok(cliente)
            Catch ex As ArgumentException
                Return BadRequest(New With {.mensaje = ex.Message})
            End Try
        End Function

        <HttpPost>
        Public Async Function Create(<FromBody> cliente As Cliente) As Task(Of IActionResult)
            Try
                Dim creado = Await _service.CrearAsync(cliente)
                Return CreatedAtAction(NameOf(GetById), New With {.id = creado.Id}, creado)
            Catch ex As ArgumentException
                Return BadRequest(New With {.mensaje = ex.Message})
            End Try
        End Function

        <HttpPut("{id:int}")>
        Public Async Function Update(id As Integer, <FromBody> cliente As Cliente) As Task(Of IActionResult)
            Try
                If Not Await _service.ActualizarAsync(id, cliente) Then
                    Return NotFound(New With {.mensaje = $"No existe el cliente con Id {id}."})
                End If
                Return NoContent()
            Catch ex As ArgumentException
                Return BadRequest(New With {.mensaje = ex.Message})
            End Try
        End Function

        <HttpDelete("{id:int}")>
        Public Async Function Delete(id As Integer) As Task(Of IActionResult)
            If Not Await _service.EliminarAsync(id) Then
                Return NotFound(New With {.mensaje = $"No existe el cliente con Id {id}."})
            End If
            Return NoContent()
        End Function
    End Class
End Namespace