﻿// <auto-generated />
using System;
using BookCatalog.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookCatalog.API.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "aal_level", new[] { "aal1", "aal2", "aal3" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "code_challenge_method", new[] { "s256", "plain" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "factor_status", new[] { "unverified", "verified" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "factor_type", new[] { "totp", "webauthn" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "pgsodium", "key_type", new[] { "aead-ietf", "aead-det", "hmacsha512", "hmacsha256", "auth", "shorthash", "generichash", "kdf", "secretbox", "secretstream", "stream_xchacha20" });
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pg_stat_statements");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pgcrypto");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pgjwt");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "uuid-ossp");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "graphql", "pg_graphql");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgroonga");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgsodium", "pgsodium");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "vault", "supabase_vault");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookCatalog.API.Model.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("AuthorName")
                        .HasColumnType("text")
                        .HasColumnName("author_name");

                    b.Property<double?>("Availability")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasColumnName("availability")
                        .HasDefaultValueSql("'0'::double precision");

                    b.Property<float?>("AverageRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasColumnName("average_rating")
                        .HasDefaultValueSql("'0'::real");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("description")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("Dimensions")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("dimensions")
                        .HasDefaultValueSql("''::text");

                    b.Property<float?>("DiscountPercentage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasColumnName("discount_percentage")
                        .HasDefaultValueSql("'0'::real");

                    b.Property<long>("FormatId")
                        .HasColumnType("bigint")
                        .HasColumnName("format_id");

                    b.Property<string>("ImageUrl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("image_url")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("Isbn13")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("isbn13")
                        .HasDefaultValueSql("''::text");

                    b.Property<double?>("ItemWeight")
                        .HasColumnType("double precision")
                        .HasColumnName("item_weight");

                    b.Property<string>("LanguageCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("language_code")
                        .HasDefaultValueSql("''::text");

                    b.Property<long?>("NumPages")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("num_pages")
                        .HasDefaultValueSql("'0'::bigint");

                    b.Property<double?>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasColumnName("price")
                        .HasDefaultValueSql("'0'::double precision");

                    b.Property<short?>("PublicationDay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("publication_day")
                        .HasDefaultValueSql("'0'::smallint");

                    b.Property<short?>("PublicationMonth")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("publication_month")
                        .HasDefaultValueSql("'0'::smallint");

                    b.Property<short?>("PublicationYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("publication_year")
                        .HasDefaultValueSql("'0'::smallint");

                    b.Property<long>("PublisherId")
                        .HasColumnType("bigint")
                        .HasColumnName("publisher_id");

                    b.Property<long?>("RatingsCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ratings_count")
                        .HasDefaultValueSql("'0'::bigint");

                    b.Property<string>("Title")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("title")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("TitleWithoutSeries")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("title_without_series")
                        .HasDefaultValueSql("''::text");

                    b.Property<string>("Url")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("url")
                        .HasDefaultValueSql("''::text");

                    b.HasKey("Id")
                        .HasName("books_pkey");

                    b.HasIndex("FormatId");

                    b.HasIndex("PublisherId");

                    b.HasIndex(new[] { "Url" }, "books_url_key")
                        .IsUnique();

                    b.ToTable("books", (string)null);
                });

            modelBuilder.Entity("BookCatalog.API.Model.BookFormat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("name")
                        .HasDefaultValueSql("''::text");

                    b.HasKey("Id")
                        .HasName("book_formats_pkey");

                    b.ToTable("book_formats", (string)null);
                });

            modelBuilder.Entity("BookCatalog.API.Model.BookGenre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("book_id");

                    b.Property<long?>("GenreId")
                        .HasColumnType("bigint")
                        .HasColumnName("genre_id");

                    b.HasKey("Id")
                        .HasName("book_genres_pkey");

                    b.HasIndex("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("book_genres", (string)null);
                });

            modelBuilder.Entity("BookCatalog.API.Model.BookPublisher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("name")
                        .HasDefaultValueSql("''::text");

                    b.HasKey("Id")
                        .HasName("book_publishers_pkey");

                    b.ToTable("book_publishers", (string)null);
                });

            modelBuilder.Entity("BookCatalog.API.Model.BookReview", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.Property<long>("BookId")
                        .HasColumnType("bigint")
                        .HasColumnName("book_id");

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateOnly?>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creation_date");

                    b.Property<decimal?>("RatingPoint")
                        .HasColumnType("numeric")
                        .HasColumnName("rating_point");

                    b.Property<string>("UserProfileImage")
                        .HasColumnType("text")
                        .HasColumnName("user_profile_image");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("UserId", "BookId")
                        .HasName("book_reviews_pkey");

                    b.HasIndex("BookId");

                    b.ToTable("book_reviews", (string)null);
                });

            modelBuilder.Entity("BookCatalog.API.Model.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("genres_pkey");

                    b.ToTable("genres", (string)null);
                });

            modelBuilder.Entity("BookCatalog.API.Model.Book", b =>
                {
                    b.HasOne("BookCatalog.API.Model.BookFormat", "Format")
                        .WithMany("Books")
                        .HasForeignKey("FormatId")
                        .IsRequired()
                        .HasConstraintName("books_format_id_fkey");

                    b.HasOne("BookCatalog.API.Model.BookPublisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .IsRequired()
                        .HasConstraintName("books_publisher_id_fkey");

                    b.Navigation("Format");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookCatalog.API.Model.BookGenre", b =>
                {
                    b.HasOne("BookCatalog.API.Model.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("book_genres_book_id_fkey");

                    b.HasOne("BookCatalog.API.Model.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("book_genres_genre_id_fkey");

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookCatalog.API.Model.BookReview", b =>
                {
                    b.HasOne("BookCatalog.API.Model.Book", "Book")
                        .WithMany("BookReviews")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("book_reviews_book_id_fkey");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookCatalog.API.Model.Book", b =>
                {
                    b.Navigation("BookGenres");

                    b.Navigation("BookReviews");
                });

            modelBuilder.Entity("BookCatalog.API.Model.BookFormat", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookCatalog.API.Model.BookPublisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookCatalog.API.Model.Genre", b =>
                {
                    b.Navigation("BookGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
