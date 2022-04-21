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

        public virtual DbSet<Carrinho> Carrinhos { get; set; }
        public virtual DbSet<CategoriaNivel1> CategoriaNivel1s { get; set; }
        public virtual DbSet<CategoriaNivel2> CategoriaNivel2s { get; set; }
        public virtual DbSet<CategoriaNivel3> CategoriaNivel3s { get; set; }
        public virtual DbSet<CategoriaNivel4> CategoriaNivel4s { get; set; }
        public virtual DbSet<Encarte> Encartes { get; set; }
        public virtual DbSet<EncarteItem> EncarteItems { get; set; }
        public virtual DbSet<LojaEstante> LojaEstantes { get; set; }
        public virtual DbSet<LojaPrateleira> LojaPrateleiras { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<ProdutoCategorium> ProdutoCategoria { get; set; }
        public virtual DbSet<ProdutoCodigoBarra> ProdutoCodigoBarras { get; set; }
        public virtual DbSet<ProdutoLoja> ProdutoLojas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioEndereco> UsuarioEnderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=bancodados-mercado.mysql.database.azure.com;userid=root_andre;password=SistemaValendo1;database=db_mercado_online;sslmode=none;connect timeout=30", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.37-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_unicode_ci");

            modelBuilder.Entity<Carrinho>(entity =>
            {
                entity.ToTable("carrinho");

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

            modelBuilder.Entity<CategoriaNivel1>(entity =>
            {
                entity.ToTable("categoria_nivel_1");

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

            modelBuilder.Entity<CategoriaNivel2>(entity =>
            {
                entity.ToTable("categoria_nivel_2");

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

            modelBuilder.Entity<CategoriaNivel3>(entity =>
            {
                entity.ToTable("categoria_nivel_3");

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

            modelBuilder.Entity<CategoriaNivel4>(entity =>
            {
                entity.ToTable("categoria_nivel_4");

                entity.HasComment("tabela com os dados da categoria nivel 4");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da categoria nivel 4");

                entity.Property(e => e.CategoriaNivel1)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_1")
                    .HasComment("referencia do codigo da categoria nivel 1");

                entity.Property(e => e.CategoriaNivel2)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_2")
                    .HasComment("referencia do codigo da categoria nivel 2");

                entity.Property(e => e.CategoriaNivel3)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_3")
                    .HasComment("referencia do codigo da categoria nivel 3");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("img")
                    .HasComment("url da imagem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome da categoria nivel 4");

                entity.Property(e => e.Ordem)
                    .HasColumnType("int(11)")
                    .HasColumnName("ordem")
                    .HasComment("ordem de exibição");
            });

            modelBuilder.Entity<Encarte>(entity =>
            {
                entity.ToTable("encarte");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("data");

                entity.Property(e => e.Frente)
                    .HasColumnType("int(11)")
                    .HasColumnName("frente");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo");

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

                entity.Property(e => e.Produto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("produto");

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<LojaEstante>(entity =>
            {
                entity.ToTable("loja_estante");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("autonumerico chave primaria da tabela");

                entity.Property(e => e.ProdutosVariados)
                    .HasColumnType("int(11)")
                    .HasColumnName("produtos_variados")
                    .HasComment("se os produtos não sao de higiene pessoal e perfumaria");
            });

            modelBuilder.Entity<LojaPrateleira>(entity =>
            {
                entity.ToTable("loja_prateleira");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("autonumerico chave primaria da tabela");

                entity.Property(e => e.Codigo)
                    .HasColumnType("int(11)")
                    .HasColumnName("codigo")
                    .HasComment("codigo para prateleira dentro da estante exemplo prateleira 10 da estante 2");

                entity.Property(e => e.EstanteLoja)
                    .HasColumnType("int(11)")
                    .HasColumnName("estante_loja")
                    .HasComment("id referente a estante na loja para venda online");

                entity.Property(e => e.Livre)
                    .HasColumnType("int(11)")
                    .HasColumnName("livre")
                    .HasComment("livre  para armazenar mais itens");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

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

            modelBuilder.Entity<ProdutoCategorium>(entity =>
            {
                entity.ToTable("produto_categoria");

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

                entity.Property(e => e.CategoriaNivel4)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_4")
                    .HasComment("referecia a categoria nivel 4");

                entity.Property(e => e.CodigoProduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("codigo_produto")
                    .HasComment("referencia ao codigo do produto");

                entity.Property(e => e.Ordem)
                    .HasColumnType("int(11)")
                    .HasColumnName("ordem");
            });

            modelBuilder.Entity<ProdutoCodigoBarra>(entity =>
            {
                entity.ToTable("produto_codigo_barra");

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

            modelBuilder.Entity<ProdutoLoja>(entity =>
            {
                entity.ToTable("produto_loja");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("autonumerico chave primaria da tabela");

                entity.Property(e => e.ConferenciaBalanco)
                    .HasColumnType("int(11)")
                    .HasColumnName("conferencia_balanco")
                    .HasComment("marcar produto com balanço verificado após entrada na prateleira");

                entity.Property(e => e.ConferenciaValidade)
                    .HasColumnType("int(11)")
                    .HasColumnName("conferencia_validade")
                    .HasComment("marcar produto com validade verificada após entrada na prateleira");

                entity.Property(e => e.Entrada)
                    .HasColumnType("datetime")
                    .HasColumnName("entrada")
                    .HasComment("data de entrada do produto");

                entity.Property(e => e.Funcionario)
                    .HasColumnType("int(11)")
                    .HasColumnName("funcionario")
                    .HasComment("referencia id da tabela funcionario");

                entity.Property(e => e.Prateleira)
                    .HasColumnType("int(11)")
                    .HasColumnName("prateleira")
                    .HasComment("referencia id da tabela loja_prateleira");

                entity.Property(e => e.Produto)
                    .HasColumnType("int(11)")
                    .HasColumnName("produto")
                    .HasComment("referencia id da tabela produto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantidade")
                    .HasComment("quantidade de itens do produto na prateleira");

                entity.Property(e => e.Validade)
                    .HasColumnType("datetime")
                    .HasColumnName("validade")
                    .HasComment("validade do produto");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Telefone })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("usuario");

                entity.HasComment("tabela com informações dos usuarios");

                entity.HasIndex(e => e.Telefone, "telefone_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela e codigo de cada cliente");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .HasColumnName("telefone")
                    .HasComment("numero de telefone do cliente");

                entity.Property(e => e.AparelhoId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("aparelho_id");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf")
                    .HasComment("cpf do cliente");

                entity.Property(e => e.Habilitado)
                    .HasColumnType("int(11)")
                    .HasColumnName("habilitado")
                    .HasDefaultValueSql("'1'")
                    .HasComment("status do cliente");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .HasColumnName("img");

                entity.Property(e => e.Nascimento)
                    .HasColumnType("datetime")
                    .HasColumnName("nascimento")
                    .HasComment("Data de nascimento  do cliente");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome do cliente");

                entity.Property(e => e.Saldo)
                    .HasPrecision(10, 2)
                    .HasColumnName("saldo")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("saldo do cliente");
            });

            modelBuilder.Entity<UsuarioEndereco>(entity =>
            {
                entity.ToTable("usuario_endereco");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cep)
                    .HasMaxLength(255)
                    .HasColumnName("cep");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .HasColumnName("complemento");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("id_usuario");

                entity.Property(e => e.Principal)
                    .HasColumnType("int(11)")
                    .HasColumnName("principal");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(255)
                    .HasColumnName("referencia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
