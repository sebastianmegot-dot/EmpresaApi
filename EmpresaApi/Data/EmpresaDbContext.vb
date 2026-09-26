Imports Microsoft.EntityFrameworkCore
Imports EmpresaApi.Models

Namespace Data
    Public Class EmpresaDbContext
        Inherits DbContext

        Public Sub New(options As DbContextOptions(Of EmpresaDbContext))
            MyBase.New(options)
        End Sub

        Public Property Clientes As DbSet(Of Cliente)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            modelBuilder.Entity(Of Cliente)(
                Sub(e)
                    e.ToTable("Clientes")
                    e.HasKey(Function(c) c.Id)
                    e.Property(Function(c) c.Id).ValueGeneratedOnAdd()
                    e.Property(Function(c) c.Nombre).HasMaxLength(100).IsUnicode(False).IsRequired()
                    e.Property(Function(c) c.Apellido).HasMaxLength(100).IsUnicode(False).IsRequired()
                    e.Property(Function(c) c.Email).HasMaxLength(150).IsUnicode(False).IsRequired()
                    e.Property(Function(c) c.Telefono).HasMaxLength(30).IsUnicode(False)
                End Sub)
        End Sub
    End Class
End Namespace