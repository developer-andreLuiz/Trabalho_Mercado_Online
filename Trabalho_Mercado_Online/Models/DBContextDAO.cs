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
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<FuncionarioCargo> FuncionarioCargos { get; set; }
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

                entity.Property(e => e.Produto)
                    .HasColumnType("int(11)")
                    .HasColumnName("produto")
                    .HasComment("referencia ao id do produto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantidade")
                    .HasComment("quantidade de itens do mesmo produto no carrinho");

                entity.Property(e => e.Usuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("usuario")
                    .HasComment("referencia ao id do usuario");
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
                    .HasComment("referencia ao id da categoria nivel 1");

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
                    .HasComment("referencia ao id da categoria nivel 1");

                entity.Property(e => e.CategoriaNivel2)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_2")
                    .HasComment("referencia ao id da categoria nivel 2");

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
                    .HasComment("referencia ao id  da categoria nivel 1");

                entity.Property(e => e.CategoriaNivel2)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_2")
                    .HasComment("referencia ao id da categoria nivel 2");

                entity.Property(e => e.CategoriaNivel3)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_3")
                    .HasComment("referencia ao id da categoria nivel 3");

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
                    .HasColumnName("id")
                    .HasComment("chave primaria do encarte");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data")
                    .HasComment("data de criação do encarte");

                entity.Property(e => e.Frente)
                    .HasColumnType("int(11)")
                    .HasColumnName("frente")
                    .HasComment("decide se é frente ou verso");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome do encarte");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo")
                    .HasComment("categoria do encarte ");

                entity.Property(e => e.Validade)
                    .HasColumnType("datetime")
                    .HasColumnName("validade")
                    .HasComment("data de validade do encarte");
            });

            modelBuilder.Entity<EncarteItem>(entity =>
            {
                entity.ToTable("encarte_item");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria do encarte_item");

                entity.Property(e => e.Encarte)
                    .HasColumnType("int(11)")
                    .HasColumnName("encarte")
                    .HasComment("id do encarte");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("img")
                    .HasComment("url da imagem");

                entity.Property(e => e.Produto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("produto")
                    .HasComment("nome do produto");

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("valor")
                    .HasComment("valor do produto");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("funcionario");

                entity.HasIndex(e => e.Senha, "senha_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela produto");

                entity.Property(e => e.Cargo)
                    .HasColumnType("int(11)")
                    .HasColumnName("cargo")
                    .HasComment("id da tabela funcionario_cargo");

                entity.Property(e => e.Endereco)
                    .HasMaxLength(255)
                    .HasColumnName("endereco")
                    .HasComment("endereço do funcionario");

                entity.Property(e => e.Habilitado)
                    .HasColumnName("habilitado")
                    .HasComment("verifica se o funcionario esta ativo na empresa");

                entity.Property(e => e.Informacao)
                    .HasMaxLength(255)
                    .HasColumnName("informacao")
                    .HasComment("informação complementar sobre o funcionario");

                entity.Property(e => e.Nivel)
                    .HasColumnType("int(11)")
                    .HasColumnName("nivel")
                    .HasComment("nivel de acesso\n\n1 Operação\n2 Supervisão\n3 Gerência\n4 Técnico\n5 Presidência");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome do funcionario");

                entity.Property(e => e.Salario)
                    .HasPrecision(10, 2)
                    .HasColumnName("salario");

                entity.Property(e => e.SalarioBonus)
                    .HasPrecision(10, 2)
                    .HasColumnName("salario_bonus");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("senha")
                    .HasComment("senha do funcionario");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("telefone")
                    .HasComment("telefone do funcionaio");

                entity.Property(e => e.ValeCompra)
                    .HasPrecision(10, 2)
                    .HasColumnName("vale_compra");
            });

            modelBuilder.Entity<FuncionarioCargo>(entity =>
            {
                entity.ToTable("funcionario_cargo");

                entity.HasIndex(e => e.Nome, "nome_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria de funcionario_cargo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasComment("nome do cargo do funcionario");
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
                    .HasComment("chave primaria da tabela loja_estante");

                entity.Property(e => e.ProdutoVariado)
                    .HasColumnType("int(11)")
                    .HasColumnName("produto_variado")
                    .HasComment("se os produtos não sao de higiene pessoal e perfumaria");
            });

            modelBuilder.Entity<LojaPrateleira>(entity =>
            {
                entity.ToTable("loja_prateleira");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("autonumerico chave primaria da tabela");

                entity.Property(e => e.Codigo)
                    .HasColumnType("int(11)")
                    .HasColumnName("codigo")
                    .HasComment("codigo da prateleira por estante \nexemplo \nestante 1 (loja_estante) prateleira 5 (codigo)\nestante 3 prateleira 5");

                entity.Property(e => e.LojaEstante)
                    .HasColumnType("int(11)")
                    .HasColumnName("loja_estante")
                    .HasComment("referente ao id de loja_estante");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.HasComment("tabela com os dados dos produtos");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela produto");

                entity.Property(e => e.CodigoLoja)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("codigo_loja")
                    .HasDefaultValueSql("'0'")
                    .HasComment("codigo interno da loja access");

                entity.Property(e => e.CustoUnitario)
                    .HasPrecision(10, 2)
                    .HasColumnName("custo_unitario")
                    .HasComment("valor de custo do produto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("descricao")
                    .HasComment("nome do produto");

                entity.Property(e => e.Embalagem)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("embalagem")
                    .HasComment("PCT - UND - CX - PESO");

                entity.Property(e => e.Gramatura)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("gramatura")
                    .HasComment("1,5L  - 50ml (sem espaço e maiusculo) kg - gr - lt - ml - und\n");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.IgualaProduto)
                    .HasColumnType("int(11)")
                    .HasColumnName("iguala_produto")
                    .HasComment("0 - 1 - 2 -3  serve para realizar alteração em produtos iguais");

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("img")
                    .HasComment("url da imagem");

                entity.Property(e => e.Informacao)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("informacao")
                    .HasComment("informação nutricional do produto");

                entity.Property(e => e.ItensCaixa)
                    .HasColumnType("int(11)")
                    .HasColumnName("itens_caixa")
                    .HasComment("quantidade de produto  na caixa");

                entity.Property(e => e.Peso)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("peso")
                    .HasComment("01526 (01,526kg)");

                entity.Property(e => e.Pronuncia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pronuncia")
                    .HasComment("leitura da descrição");

                entity.Property(e => e.Validade)
                    .HasColumnName("validade")
                    .HasComment("se o produto é perecivel ou nao");

                entity.Property(e => e.ValorPromocao)
                    .HasPrecision(10, 2)
                    .HasColumnName("valor_promocao")
                    .HasComment("valor de promoção do produto");

                entity.Property(e => e.ValorVenda)
                    .HasPrecision(10, 2)
                    .HasColumnName("valor_venda")
                    .HasComment("valor de venda do produto");

                entity.Property(e => e.Volume)
                    .HasColumnType("int(11)")
                    .HasColumnName("volume")
                    .HasComment("30 - caixa volume =100 (cabe 3 na caixa)volume do produto");
            });

            modelBuilder.Entity<ProdutoCategorium>(entity =>
            {
                entity.ToTable("produto_categoria");

                entity.HasComment("tabela com os dados dos produtos relacionando com as categorias");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela produto_categoria");

                entity.Property(e => e.CategoriaNivel1)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_1")
                    .HasComment("referecia ao id de categoria nivel 1");

                entity.Property(e => e.CategoriaNivel2)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_2")
                    .HasComment("referecia ao id de categoria nivel 2");

                entity.Property(e => e.CategoriaNivel3)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_3")
                    .HasComment("referecia ao id de categoria nivel 3");

                entity.Property(e => e.CategoriaNivel4)
                    .HasColumnType("int(11)")
                    .HasColumnName("categoria_nivel_4")
                    .HasComment("referecia ao id de categoria nivel 4");

                entity.Property(e => e.Ordem)
                    .HasColumnType("int(11)")
                    .HasColumnName("ordem")
                    .HasComment("ordem de exibição");

                entity.Property(e => e.Produto)
                    .HasColumnType("int(11)")
                    .HasColumnName("produto")
                    .HasComment("referencia ao id do produto");
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

                entity.Property(e => e.Produto)
                    .HasColumnType("int(11)")
                    .HasColumnName("produto")
                    .HasComment("referencia ao id de produto");
            });

            modelBuilder.Entity<ProdutoLoja>(entity =>
            {
                entity.ToTable("produto_loja");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela produto_loja");

                entity.Property(e => e.ConferenciaBalanco)
                    .HasColumnType("int(11)")
                    .HasColumnName("conferencia_balanco")
                    .HasComment("marcar produto com balanço verificado após entrada na prateleira");

                entity.Property(e => e.ConferenciaValidade)
                    .HasColumnType("int(11)")
                    .HasColumnName("conferencia_validade")
                    .HasComment("marcar produto com validade verificada após entrada na prateleira");

                entity.Property(e => e.CustoUnitario)
                    .HasPrecision(10, 2)
                    .HasColumnName("custo_unitario");

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
                    .HasComment("referencia ao id da tabela loja_prateleira");

                entity.Property(e => e.Produto)
                    .HasColumnType("int(11)")
                    .HasColumnName("produto")
                    .HasComment("referencia ao id da tabela produto");

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
                entity.ToTable("usuario");

                entity.HasComment("tabela com informações dos usuarios");

                entity.HasIndex(e => e.Telefone, "telefone_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela usuario");

                entity.Property(e => e.AparelhoId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("aparelho_id")
                    .HasComment("id do dispositivo do usuario logado");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf")
                    .HasComment("cpf do usuario");

                entity.Property(e => e.Habilitado)
                    .HasColumnType("int(11)")
                    .HasColumnName("habilitado")
                    .HasDefaultValueSql("'1'")
                    .HasComment("status do usuario");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .HasColumnName("img");

                entity.Property(e => e.Nascimento)
                    .HasColumnType("datetime")
                    .HasColumnName("nascimento")
                    .HasComment("Data de nascimento  do usuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome")
                    .HasComment("nome do usuario");

                entity.Property(e => e.Saldo)
                    .HasPrecision(10, 2)
                    .HasColumnName("saldo")
                    .HasDefaultValueSql("'0.00'")
                    .HasComment("saldo do cliente");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("telefone")
                    .HasComment("numero de telefone do usuario");
            });

            modelBuilder.Entity<UsuarioEndereco>(entity =>
            {
                entity.ToTable("usuario_endereco");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("chave primaria da tabela usuario");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("cep")
                    .HasComment("cep do endereço cadastrado");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .HasColumnName("complemento")
                    .HasComment("complemento do endereço (opcional)");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("endereco")
                    .HasComment("endereço do usuario");

                entity.Property(e => e.Principal)
                    .HasColumnType("int(11)")
                    .HasColumnName("principal")
                    .HasComment("verifica se o endereço é o principal");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(255)
                    .HasColumnName("referencia")
                    .HasComment("ponto de referencia do endereço (opcional)");

                entity.Property(e => e.Usuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("usuario")
                    .HasComment("referencia ao id de usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
