﻿// <auto-generated />
using System;
using Consultoria.Bee.Data.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Consultoria.Bee.Data.EF.Migrations
{
    [DbContext(typeof(BeeContext))]
    partial class BeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Consultoria.Bee.Domain.Entities.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoriaId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataInativacao");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Consultoria.Bee.Domain.Entities.ProdutoCategoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime?>("DataInativacao");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("ProdutoCategoria");
                });

            modelBuilder.Entity("Consultoria.Bee.Domain.Entities.Produto", b =>
                {
                    b.HasOne("Consultoria.Bee.Domain.Entities.ProdutoCategoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
