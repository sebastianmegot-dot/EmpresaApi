Imports System.Net.Mail
Imports EmpresaApi.Models
Imports EmpresaApi.Repositories

Namespace Services
    Public Class ClienteService
        Implements IClienteService

        Private ReadOnly _repo As IClienteRepository

        Public Sub New(repo As IClienteRepository)
            _repo = repo
        End Sub

        Public Async Function ObtenerTodosAsync() As Task(Of List(Of Cliente)) _
            Implements IClienteService.ObtenerTodosAsync
            Return Await _repo.ObtenerTodosAsync()
        End Function

        Public Async Function ObtenerPorIdAsync(id As Integer) As Task(Of Cliente) _
            Implements IClienteService.ObtenerPorIdAsync
            If id <= 0 Then Throw New ArgumentException("El Id debe ser mayor a cero.")
            Return Await _repo.ObtenerPorIdAsync(id)
        End Function

        Public Async Function CrearAsync(cliente As Cliente) As Task(Of Cliente) _
            Implements IClienteService.CrearAsync
            Normalizar(cliente)
            Validar(cliente)
            If Await _repo.ExisteEmailAsync(cliente.Email) Then
                Throw New ArgumentException("Ya existe un cliente con ese email.")
            End If
            cliente.Id = 0 ' El Id lo genera SQL Server (IDENTITY)
            Return Await _repo.AgregarAsync(cliente)
        End Function

        Public Async Function ActualizarAsync(id As Integer, datos As Cliente) As Task(Of Boolean) _
            Implements IClienteService.ActualizarAsync
            Dim existente = Await _repo.ObtenerPorIdAsync(id)
            If existente Is Nothing Then Return False

            Normalizar(datos)
            Validar(datos)
            If Await _repo.ExisteEmailAsync(datos.Email, id) Then
                Throw New ArgumentException("Ya existe otro cliente con ese email.")
            End If

            existente.Nombre = datos.Nombre
            existente.Apellido = datos.Apellido
            existente.Email = datos.Email
            existente.Telefono = datos.Telefono
            Await _repo.ActualizarAsync(existente)
            Return True
        End Function

        Public Async Function EliminarAsync(id As Integer) As Task(Of Boolean) _
            Implements IClienteService.EliminarAsync
            Dim existente = Await _repo.ObtenerPorIdAsync(id)
            If existente Is Nothing Then Return False
            Await _repo.EliminarAsync(existente)
            Return True
        End Function


        Private Sub Normalizar(c As Cliente)
            If c Is Nothing Then Throw New ArgumentException("Los datos del cliente son obligatorios.")
            c.Nombre = c.Nombre?.Trim()
            c.Apellido = c.Apellido?.Trim()
            c.Email = c.Email?.Trim().ToLower()
            c.Telefono = c.Telefono?.Trim()
        End Sub

        Private Sub Validar(c As Cliente)
            If String.IsNullOrWhiteSpace(c.Nombre) Then Throw New ArgumentException("El nombre es obligatorio.")
            If String.IsNullOrWhiteSpace(c.Apellido) Then Throw New ArgumentException("El apellido es obligatorio.")
            If String.IsNullOrWhiteSpace(c.Email) Then Throw New ArgumentException("El email es obligatorio.")
            If c.Nombre.Length > 100 Then Throw New ArgumentException("El nombre no puede superar 100 caracteres.")
            If c.Apellido.Length > 100 Then Throw New ArgumentException("El apellido no puede superar 100 caracteres.")
            If c.Email.Length > 150 Then Throw New ArgumentException("El email no puede superar 150 caracteres.")
            If c.Telefono IsNot Nothing AndAlso c.Telefono.Length > 30 Then
                Throw New ArgumentException("El teléfono no puede superar 30 caracteres.")
            End If
            Dim tmp As MailAddress = Nothing
            If Not MailAddress.TryCreate(c.Email, tmp) Then
                Throw New ArgumentException("El formato del email no es válido.")
            End If
        End Sub
    End Class
End Namespace