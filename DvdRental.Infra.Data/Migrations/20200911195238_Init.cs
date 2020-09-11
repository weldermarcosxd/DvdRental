using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

namespace DvdRental.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:mpaa_rating", "G,PG,PG-13,R,NC-17");

            migrationBuilder.CreateSequence(
                name: "actor_actor_id_seq");

            migrationBuilder.CreateSequence(
                name: "address_address_id_seq");

            migrationBuilder.CreateSequence(
                name: "category_category_id_seq");

            migrationBuilder.CreateSequence(
                name: "city_city_id_seq");

            migrationBuilder.CreateSequence(
                name: "country_country_id_seq");

            migrationBuilder.CreateSequence(
                name: "customer_customer_id_seq");

            migrationBuilder.CreateSequence(
                name: "film_film_id_seq");

            migrationBuilder.CreateSequence(
                name: "inventory_inventory_id_seq");

            migrationBuilder.CreateSequence(
                name: "language_language_id_seq");

            migrationBuilder.CreateSequence(
                name: "payment_payment_id_seq");

            migrationBuilder.CreateSequence(
                name: "rental_rental_id_seq");

            migrationBuilder.CreateSequence(
                name: "staff_staff_id_seq");

            migrationBuilder.CreateSequence(
                name: "store_store_id_seq");

            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    actor_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 45, nullable: false),
                    last_name = table.Column<string>(maxLength: 45, nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actor", x => x.actor_id);
                });

            migrationBuilder.CreateTable(
                name: "actor_info",
                columns: table => new
                {
                    actor_id = table.Column<int>(nullable: true),
                    first_name = table.Column<string>(maxLength: 45, nullable: true),
                    last_name = table.Column<string>(maxLength: 45, nullable: true),
                    film_info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    country_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    country = table.Column<string>(maxLength: 50, nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_list",
                columns: table => new
                {
                    id = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    zipcode = table.Column<string>(name: "zip code", maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 20, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    country = table.Column<string>(maxLength: 50, nullable: true),
                    notes = table.Column<string>(nullable: true),
                    sid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "film_list",
                columns: table => new
                {
                    fid = table.Column<int>(nullable: true),
                    title = table.Column<string>(maxLength: 255, nullable: true),
                    description = table.Column<string>(nullable: true),
                    category = table.Column<string>(maxLength: 25, nullable: true),
                    price = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    length = table.Column<short>(nullable: true),
                    actors = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    language_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(fixedLength: true, maxLength: 20, nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "nicer_but_slower_film_list",
                columns: table => new
                {
                    fid = table.Column<int>(nullable: true),
                    title = table.Column<string>(maxLength: 255, nullable: true),
                    description = table.Column<string>(nullable: true),
                    category = table.Column<string>(maxLength: 25, nullable: true),
                    price = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    length = table.Column<short>(nullable: true),
                    actors = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sales_by_film_category",
                columns: table => new
                {
                    category = table.Column<string>(maxLength: 25, nullable: true),
                    total_sales = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sales_by_store",
                columns: table => new
                {
                    store = table.Column<string>(nullable: true),
                    manager = table.Column<string>(nullable: true),
                    total_sales = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "staff_list",
                columns: table => new
                {
                    id = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    zipcode = table.Column<string>(name: "zip code", maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 20, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    country = table.Column<string>(maxLength: 50, nullable: true),
                    sid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    city_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city = table.Column<string>(maxLength: 50, nullable: false),
                    country_id = table.Column<int>(nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.city_id);
                    table.ForeignKey(
                        name: "fk_city",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    film_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(maxLength: 255, nullable: false),
                    description = table.Column<string>(nullable: true),
                    release_year = table.Column<int>(nullable: true),
                    language_id = table.Column<int>(nullable: false),
                    rental_duration = table.Column<short>(nullable: false, defaultValueSql: "3"),
                    rental_rate = table.Column<decimal>(type: "numeric(4,2)", nullable: false, defaultValueSql: "4.99"),
                    length = table.Column<short>(nullable: true),
                    replacement_cost = table.Column<decimal>(type: "numeric(5,2)", nullable: false, defaultValueSql: "19.99"),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    special_features = table.Column<string[]>(nullable: true),
                    fulltext = table.Column<NpgsqlTsVector>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.film_id);
                    table.ForeignKey(
                        name: "film_language_id_fkey",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "language_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(maxLength: 50, nullable: false),
                    address2 = table.Column<string>(maxLength: 50, nullable: true),
                    district = table.Column<string>(maxLength: 20, nullable: false),
                    city_id = table.Column<int>(nullable: false),
                    postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 20, nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                    table.ForeignKey(
                        name: "fk_address_city",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "film_actor",
                columns: table => new
                {
                    actor_id = table.Column<int>(nullable: false),
                    film_id = table.Column<int>(nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("film_actor_pkey", x => new { x.actor_id, x.film_id });
                    table.ForeignKey(
                        name: "film_actor_actor_id_fkey",
                        column: x => x.actor_id,
                        principalTable: "actor",
                        principalColumn: "actor_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "film_actor_film_id_fkey",
                        column: x => x.film_id,
                        principalTable: "film",
                        principalColumn: "film_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "film_category",
                columns: table => new
                {
                    film_id = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("film_category_pkey", x => new { x.film_id, x.category_id });
                    table.ForeignKey(
                        name: "film_category_category_id_fkey",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "film_category_film_id_fkey",
                        column: x => x.film_id,
                        principalTable: "film",
                        principalColumn: "film_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    inventory_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    film_id = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.inventory_id);
                    table.ForeignKey(
                        name: "inventory_film_id_fkey",
                        column: x => x.film_id,
                        principalTable: "film",
                        principalColumn: "film_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    store_id = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(maxLength: 45, nullable: false),
                    last_name = table.Column<string>(maxLength: 45, nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    address_id = table.Column<int>(nullable: false),
                    activebool = table.Column<bool>(nullable: false, defaultValueSql: "true"),
                    create_date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "('now'::text)::date"),
                    last_update = table.Column<DateTime>(nullable: true, defaultValueSql: "now()"),
                    active = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                    table.ForeignKey(
                        name: "customer_address_id_fkey",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    staff_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 45, nullable: false),
                    last_name = table.Column<string>(maxLength: 45, nullable: false),
                    address_id = table.Column<int>(nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    store_id = table.Column<int>(nullable: false),
                    active = table.Column<bool>(nullable: false, defaultValueSql: "true"),
                    username = table.Column<string>(maxLength: 16, nullable: false),
                    password = table.Column<string>(maxLength: 40, nullable: true),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.staff_id);
                    table.ForeignKey(
                        name: "staff_address_id_fkey",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rental",
                columns: table => new
                {
                    rental_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rental_date = table.Column<DateTime>(nullable: false),
                    inventory_id = table.Column<int>(nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    return_date = table.Column<DateTime>(nullable: true),
                    staff_id = table.Column<int>(nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rental", x => x.rental_id);
                    table.ForeignKey(
                        name: "rental_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "rental_inventory_id_fkey",
                        column: x => x.inventory_id,
                        principalTable: "inventory",
                        principalColumn: "inventory_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "rental_staff_id_key",
                        column: x => x.staff_id,
                        principalTable: "staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "store",
                columns: table => new
                {
                    store_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    manager_staff_id = table.Column<int>(nullable: false),
                    address_id = table.Column<int>(nullable: false),
                    last_update = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store", x => x.store_id);
                    table.ForeignKey(
                        name: "store_address_id_fkey",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "store_manager_staff_id_fkey",
                        column: x => x.manager_staff_id,
                        principalTable: "staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    payment_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(nullable: false),
                    staff_id = table.Column<int>(nullable: false),
                    rental_id = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    payment_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.payment_id);
                    table.ForeignKey(
                        name: "payment_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "payment_rental_id_fkey",
                        column: x => x.rental_id,
                        principalTable: "rental",
                        principalColumn: "rental_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "payment_staff_id_fkey",
                        column: x => x.staff_id,
                        principalTable: "staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "idx_actor_last_name",
                table: "actor",
                column: "last_name");

            migrationBuilder.CreateIndex(
                name: "idx_fk_city_id",
                table: "address",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "idx_fk_country_id",
                table: "city",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "idx_fk_address_id",
                table: "customer",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "idx_last_name",
                table: "customer",
                column: "last_name");

            migrationBuilder.CreateIndex(
                name: "idx_fk_store_id",
                table: "customer",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "film_fulltext_idx",
                table: "film",
                column: "fulltext")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "idx_fk_language_id",
                table: "film",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "idx_title",
                table: "film",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "idx_fk_film_id",
                table: "film_actor",
                column: "film_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_category_category_id",
                table: "film_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_film_id",
                table: "inventory",
                column: "film_id");

            migrationBuilder.CreateIndex(
                name: "idx_store_id_film_id",
                table: "inventory",
                columns: new[] { "store_id", "film_id" });

            migrationBuilder.CreateIndex(
                name: "idx_fk_customer_id",
                table: "payment",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "idx_fk_rental_id",
                table: "payment",
                column: "rental_id");

            migrationBuilder.CreateIndex(
                name: "idx_fk_staff_id",
                table: "payment",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_rental_customer_id",
                table: "rental",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "idx_fk_inventory_id",
                table: "rental",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "IX_rental_staff_id",
                table: "rental",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "idx_unq_rental_rental_date_inventory_id_customer_id",
                table: "rental",
                columns: new[] { "rental_date", "inventory_id", "customer_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_staff_address_id",
                table: "staff",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_address_id",
                table: "store",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "idx_unq_manager_staff_id",
                table: "store",
                column: "manager_staff_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actor_info");

            migrationBuilder.DropTable(
                name: "customer_list");

            migrationBuilder.DropTable(
                name: "film_actor");

            migrationBuilder.DropTable(
                name: "film_category");

            migrationBuilder.DropTable(
                name: "film_list");

            migrationBuilder.DropTable(
                name: "nicer_but_slower_film_list");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "sales_by_film_category");

            migrationBuilder.DropTable(
                name: "sales_by_store");

            migrationBuilder.DropTable(
                name: "staff_list");

            migrationBuilder.DropTable(
                name: "store");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "rental");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "film");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropSequence(
                name: "actor_actor_id_seq");

            migrationBuilder.DropSequence(
                name: "address_address_id_seq");

            migrationBuilder.DropSequence(
                name: "category_category_id_seq");

            migrationBuilder.DropSequence(
                name: "city_city_id_seq");

            migrationBuilder.DropSequence(
                name: "country_country_id_seq");

            migrationBuilder.DropSequence(
                name: "customer_customer_id_seq");

            migrationBuilder.DropSequence(
                name: "film_film_id_seq");

            migrationBuilder.DropSequence(
                name: "inventory_inventory_id_seq");

            migrationBuilder.DropSequence(
                name: "language_language_id_seq");

            migrationBuilder.DropSequence(
                name: "payment_payment_id_seq");

            migrationBuilder.DropSequence(
                name: "rental_rental_id_seq");

            migrationBuilder.DropSequence(
                name: "staff_staff_id_seq");

            migrationBuilder.DropSequence(
                name: "store_store_id_seq");
        }
    }
}
