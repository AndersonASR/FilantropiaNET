Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class Model1
	Inherits DbContext

	Public Sub New()
		MyBase.New("name=Modelo")
	End Sub

	Public Overridable Property Aplicativos As DbSet(Of Aplicativos)
	Public Overridable Property AplicativosBancos As DbSet(Of AplicativosBancos)
	Public Overridable Property Bancos As DbSet(Of Bancos)
	Public Overridable Property Boletos As DbSet(Of Boletos)
	Public Overridable Property EMails As DbSet(Of EMails)
	Public Overridable Property Enderecos As DbSet(Of Enderecos)
	Public Overridable Property Pessoas As DbSet(Of Pessoas)
	Public Overridable Property Remessas As DbSet(Of Remessas)
	Public Overridable Property Retornos As DbSet(Of Retornos)
	Public Overridable Property Status As DbSet(Of Status)
	Public Overridable Property Telefones As DbSet(Of Telefones)
	Public Overridable Property TiposPessoas As DbSet(Of TiposPessoas)

	Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
		modelBuilder.Entity(Of AplicativosBancos)() _
			.HasMany(Function(e) e.Boletos) _
			.WithRequired(Function(e) e.AplicativosBancos) _
			.HasForeignKey(Function(e) e.IDSERVICO) _
			.WillCascadeOnDelete(False)

		modelBuilder.Entity(Of Bancos)() _
			.Property(Function(e) e.BANCO) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Bancos)() _
			.Property(Function(e) e._Alias) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Bancos)() _
			.HasMany(Function(e) e.AplicativosBancos) _
			.WithRequired(Function(e) e.Bancos) _
			.HasForeignKey(Function(e) e.IDBanco) _
			.WillCascadeOnDelete(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.EspecieDocumento) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.NumeroDocumento) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.NossoNumero) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.DataGeracao) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.DataProcessamento) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.DataEmissao) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.DataVencimento) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.DataPagamento) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.NumeroControle) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.Aceite) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.DataDesconto) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.MensagemInstrucaoCaixa) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.MensagemRemessa) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.Instrucao1) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.InstrucaoAux1) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.Instrucao2) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.InstrucaoAux2) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.Instrucao3) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.InstrucaoAux3) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Boletos)() _
			.Property(Function(e) e.NomeArquivo) _
			.IsUnicode(False)

		modelBuilder.Entity(Of EMails)() _
			.Property(Function(e) e.EMail) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Enderecos)() _
			.Property(Function(e) e.Logradouro) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Enderecos)() _
			.Property(Function(e) e.Complemento) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Enderecos)() _
			.Property(Function(e) e.Bairro) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Enderecos)() _
			.Property(Function(e) e.Cidade) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Enderecos)() _
			.Property(Function(e) e.UF) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Enderecos)() _
			.Property(Function(e) e.OBS) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Pessoas)() _
			.Property(Function(e) e.Nome) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Pessoas)() _
			.Property(Function(e) e.Obs) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Pessoas)() _
			.HasMany(Function(e) e.Boletos) _
			.WithRequired(Function(e) e.Pessoas) _
			.HasForeignKey(Function(e) e.IDCedente) _
			.WillCascadeOnDelete(False)

		modelBuilder.Entity(Of Pessoas)() _
			.HasMany(Function(e) e.Boletos1) _
			.WithRequired(Function(e) e.Pessoas1) _
			.HasForeignKey(Function(e) e.IDSacado) _
			.WillCascadeOnDelete(False)

		modelBuilder.Entity(Of Remessas)() _
			.Property(Function(e) e.DataGravacao) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Remessas)() _
			.Property(Function(e) e.NomeArquivo) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Retornos)() _
			.Property(Function(e) e.DataProcessamento) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Retornos)() _
			.Property(Function(e) e.NomeArquivo) _
			.IsUnicode(False)

		modelBuilder.Entity(Of Status)() _
			.Property(Function(e) e.Status1) _
			.IsUnicode(False)

		modelBuilder.Entity(Of TiposPessoas)() _
			.Property(Function(e) e.Tipo) _
			.IsUnicode(False)

		modelBuilder.Entity(Of TiposPessoas)() _
			.HasMany(Function(e) e.Pessoas) _
			.WithRequired(Function(e) e.TiposPessoas) _
			.HasForeignKey(Function(e) e.IDTipoPessoa) _
			.WillCascadeOnDelete(False)
	End Sub
End Class
