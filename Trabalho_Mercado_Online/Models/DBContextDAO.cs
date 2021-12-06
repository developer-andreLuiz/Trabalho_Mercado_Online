using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class DBContextDAO : DbContext
    {
        public DBContextDAO()
        {
        }

        public DBContextDAO(DbContextOptions<DBContextDAO> options)
            : base(options)
        {
        }

        public virtual DbSet<Bairro> Bairros { get; set; }
        public virtual DbSet<Carrinho> Carrinhos { get; set; }
        public virtual DbSet<CategoriasNivel1> CategoriasNivel1s { get; set; }
        public virtual DbSet<CategoriasNivel2> CategoriasNivel2s { get; set; }
        public virtual DbSet<CategoriasNivel3> CategoriasNivel3s { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Encarte> Encartes { get; set; }
        public virtual DbSet<EncarteItem> EncarteItems { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<LocaisEntrega> LocaisEntregas { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutosCategorium> ProdutosCategoria { get; set; }
        public virtual DbSet<ProdutosCodigoBarra> ProdutosCodigoBarras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=dbmercado.mysql.database.azure.com;userid=root_andre;password=SistemaValendo1;database=db_mercado_online;sslmode=none;connect timeout=30", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_unicode_ci");

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.ToTable("bairros");

                entity.HasComment("tabela com todos os bairros");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela ");

                entity.Property(e => e.CodigoBairro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_bairro")
                    .HasComment("codigo do bairro");

                entity.Property(e => e.CodigoEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_estado")
                    .HasComment("codigo do estado");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_municipio")
                    .HasComment("codigo do municipio");

                entity.Property(e => e.NomeBairro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome_bairro")
                    .HasComment("nome do bairro");
            });

            modelBuilder.Entity<Carrinho>(entity =>
            {
                entity.ToTable("carrinhos");

                entity.HasComment("tabela com os dados do carrinho dos clientes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela");

                entity.Property(e => e.CodigoCliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("codigo_cliente")
                    .HasComment("referencia do codigo do cliente");

                entity.Property(e => e.CodigoProduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("codigo_produto")
                    .HasComment("referencia do codigo do produto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantidade")
                    .HasComment("quantidade de itens do mesmo produto no carrinho");
            });

            modelBuilder.Entity<CategoriasNivel1>(entity =>
            {
                entity.ToTable("categorias_nivel_1");

                entity.HasComment("tabela com os dados da categoria nivel 1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da categoria nivel 1");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("img")
                    .HasComment("url da imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome da categoria nivel 1");

                entity.Property(e => e.Ordem)
                    .HasColumnType("int(11)")
                    .HasColumnName("ordem")
                    .HasComment("ordem de exibição");
            });

            modelBuilder.Entity<CategoriasNivel2>(entity =>
            {
                entity.ToTable("categorias_nivel_2");

                entity.HasComment("tabela com os dados da categoria nivel 2");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da categoria nivel 2");

                entity.Property(e => e.CategoriaNivel1)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_1")
                    .HasComment("referencia codigo da categoria nivel 1");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("img")
                    .HasComment("url da imgagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome da categoria nivel 2");

                entity.Property(e => e.Ordem)
                    .HasColumnType("int(11)")
                    .HasColumnName("ordem")
                    .HasComment("ordem de exibição");
            });

            modelBuilder.Entity<CategoriasNivel3>(entity =>
            {
                entity.ToTable("categorias_nivel_3");

                entity.HasComment("tabela com os dados da categoria nivel 3");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da categoria nivel 3");

                entity.Property(e => e.CategoriaNivel1)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_1")
                    .HasComment("referencia do codigo da categoria nivel 1");

                entity.Property(e => e.CategoriaNivel2)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_2")
                    .HasComment("referencia do codigo da categoria nivel 2");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("img")
                    .HasComment("url da imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome da categoria nivel 3");

                entity.Property(e => e.Ordem)
                    .HasColumnType("int(11)")
                    .HasColumnName("ordem")
                    .HasComment("ordem de exibição");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.HasComment("tabela com informações dos clientes");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela e codigo de cada cliente");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("celular")
                    .HasComment("numero de telefone do cliente");

                entity.Property(e => e.CodigoBairro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_bairro")
                    .HasComment("referencia do codigo do bairro de entrega");

                entity.Property(e => e.CodigoEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_estado")
                    .HasComment("referencia do codigo do estado de entrega");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_municipio")
                    .HasComment("referencia do codigo do municipio de entrega");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .HasColumnName("complemento")
                    .HasComment("complemento de endereço ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("endereco")
                    .HasComment("endereço de entrega da compra");

                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasColumnName("habilitado")
                    .HasDefaultValueSql("'1'")
                    .HasComment("status do cliente");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome do cliente");

                entity.Property(e => e.Saldo)
                    .HasPrecision(2)
                    .HasColumnName("saldo")
                    .HasComment("saldo do cliente");
            });

            modelBuilder.Entity<Encarte>(entity =>
            {
                entity.ToTable("encarte");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome");

                entity.Property(e => e.Validade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("validade");
            });

            modelBuilder.Entity<EncarteItem>(entity =>
            {
                entity.ToTable("encarte_item");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IdEncarte)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_encarte");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("img");

                entity.Property(e => e.Pos)
                    .HasColumnType("int(11)")
                    .HasColumnName("pos");

                entity.Property(e => e.Produto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("produto");

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estados");

                entity.HasComment("tabela com todos os estados ");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela");

                entity.Property(e => e.CodigoEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_estado")
                    .HasComment("codigo do estado");

                entity.Property(e => e.NomeEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome_estado")
                    .HasComment("nome do estado");
            });

            modelBuilder.Entity<LocaisEntrega>(entity =>
            {
                entity.ToTable("locais_entrega");

                entity.HasComment("tabela com objetivo de informar as localidades com entrega disponivel");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CodigoBairro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_bairro")
                    .HasComment("codigo do bairro");

                entity.Property(e => e.CodigoEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_estado")
                    .HasComment("codigo do estado");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_municipio")
                    .HasComment("codigo do municipio");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("municipios");

                entity.HasComment("tabela com todos os municipio ");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela");

                entity.Property(e => e.CodigoEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_estado")
                    .HasComment("codigo do estado");

                entity.Property(e => e.CodigoMunicipio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_municipio")
                    .HasComment("codigo do municipio");

                entity.Property(e => e.NomeMunicipio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome_municipio")
                    .HasComment("nome do municipio");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produtos");

                entity.HasComment("tabela com os dados dos produtos");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("autonumerico chave primaria da tabela");

                entity.Property(e => e.CodigoLoja)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_loja")
                    .HasDefaultValueSql("'0'")
                    .HasComment("numero de codigo interno da loja\\n");

                entity.Property(e => e.CustoUnitario)
                    .HasColumnName("custo_unitario")
                    .HasComment("valor de custo do produto\\\\n");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("descricao")
                    .HasComment("nome do produto\n");

                entity.Property(e => e.Embalagem)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("embalagem")
                    .HasComment("PCT - UND - CX - PESO\n");

                entity.Property(e => e.Gramatura)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("gramatura")
                    .HasComment("1,5L  - 50ml (sem espaço e maiusculo) kg - gr - lt - ml - und\n");

                entity.Property(e => e.IgualaProduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("iguala_produto")
                    .HasComment("0 - 1 - 2 -3 \nserve para realizar alteração em produtos iguais");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("img")
                    .HasComment("url -jpg\n");

                entity.Property(e => e.Informacao)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("informacao")
                    .HasComment("informação nutricional do produto\n");

                entity.Property(e => e.ItensCaixa)
                    .HasColumnType("int(11)")
                    .HasColumnName("itens_caixa")
                    .HasComment("quantidade de produto  na caixa\n");

                entity.Property(e => e.Peso)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("peso")
                    .HasComment("01526 (01,526kg)\n");

                entity.Property(e => e.Pronuncia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pronuncia")
                    .HasComment("leitura da descrição\n");

                entity.Property(e => e.Validade)
                    .HasColumnName("validade")
                    .HasComment("se o produto é perecivel ou nao\n");

                entity.Property(e => e.ValorPromocao)
                    .HasColumnName("valor_promocao")
                    .HasComment("valor de promoção do produto\\\\n");

                entity.Property(e => e.ValorVenda)
                    .HasColumnName("valor_venda")
                    .HasComment("valor de venda do produto\\\\n");

                entity.Property(e => e.Volume)
                    .HasColumnType("int(11)")
                    .HasColumnName("volume")
                    .HasComment("30 - caixa volume =100 (cabe 3 na caixa)volume do produto\n");
            });

            modelBuilder.Entity<ProdutosCategorium>(entity =>
            {
                entity.ToTable("produtos_categoria");

                entity.HasComment("tabela com os dados dos produtos relacionando com as categorias");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("autonumerico chave primaria da tabela");

                entity.Property(e => e.CategoriaNivel1)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_1")
                    .HasComment("referecia a categoria nivel 1");

                entity.Property(e => e.CategoriaNivel2)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_2")
                    .HasComment("referecia a categoria nivel 2");

                entity.Property(e => e.CategoriaNivel3)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_3")
                    .HasComment("referecia a categoria nivel 3");

                entity.Property(e => e.CodigoProduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("codigo_produto")
                    .HasComment("referencia ao codigo do produto");

                entity.Property(e => e.Ordem)
                    .HasColumnType("int(11)")
                    .HasColumnName("ordem");
            });

            modelBuilder.Entity<ProdutosCodigoBarra>(entity =>
            {
                entity.ToTable("produtos_codigo_barra");

                entity.HasComment("tabela com dados dos codigos de barra relacionando com o codigo do produto");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela");

                entity.Property(e => e.CodigoBarra)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_barra")
                    .HasComment("codigo de barra do produto");

                entity.Property(e => e.CodigoProduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("codigo_produto")
                    .HasComment("referencia do codigo do produto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
