using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ges_commande.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "livreur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updateat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livreur", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prix = table.Column<double>(type: "double", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    createat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updateat = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produit", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    login = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<int>(type: "int", nullable: false),
                    createat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updateat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Solde = table.Column<double>(type: "double", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updateat = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_client_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "commande",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCommande = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PrixTotal = table.Column<double>(type: "double", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    LivreurId = table.Column<int>(type: "int", nullable: false),
                    paiementId = table.Column<int>(type: "int", nullable: false),
                    createat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updateat = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commande", x => x.Id);
                    table.ForeignKey(
                        name: "FK_commande_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_commande_livreur_LivreurId",
                        column: x => x.LivreurId,
                        principalTable: "livreur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detailCommande",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prix = table.Column<double>(type: "double", nullable: false),
                    qteCommande = table.Column<double>(type: "double", nullable: false),
                    commandeID = table.Column<int>(type: "int", nullable: false),
                    produitsId = table.Column<int>(type: "int", nullable: false),
                    produitID = table.Column<int>(type: "int", nullable: false),
                    createat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updateat = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailCommande", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detailCommande_commande_commandeID",
                        column: x => x.commandeID,
                        principalTable: "commande",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailCommande_produit_produitsId",
                        column: x => x.produitsId,
                        principalTable: "produit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paiement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    commandeId = table.Column<int>(type: "int", nullable: false),
                    reduction = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    createat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updateat = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paiement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paiement_commande_commandeId",
                        column: x => x.commandeId,
                        principalTable: "commande",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_client_userId",
                table: "client",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_commande_ClientId",
                table: "commande",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_commande_LivreurId",
                table: "commande",
                column: "LivreurId");

            migrationBuilder.CreateIndex(
                name: "IX_detailCommande_commandeID",
                table: "detailCommande",
                column: "commandeID");

            migrationBuilder.CreateIndex(
                name: "IX_detailCommande_produitsId",
                table: "detailCommande",
                column: "produitsId");

            migrationBuilder.CreateIndex(
                name: "IX_paiement_commandeId",
                table: "paiement",
                column: "commandeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detailCommande");

            migrationBuilder.DropTable(
                name: "paiement");

            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "commande");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "livreur");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
