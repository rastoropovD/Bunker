using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BunkerApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "characters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Profession = table.Column<string>(type: "text", nullable: false),
                    Health = table.Column<string>(type: "text", nullable: false),
                    Phobia = table.Column<string>(type: "text", nullable: false),
                    Hobby = table.Column<string>(type: "text", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: false),
                    CreatedByAI = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "disasters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SeverityLevel = table.Column<int>(type: "integer", nullable: false),
                    GeneratedByAI = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastActiveAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "game_sessions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HostPlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    InviteCode = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DisasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_game_sessions_disasters_DisasterId",
                        column: x => x.DisasterId,
                        principalSchema: "public",
                        principalTable: "disasters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_game_sessions_players_HostPlayerId",
                        column: x => x.HostPlayerId,
                        principalSchema: "public",
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_logs",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: true),
                    ActionType = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_game_logs_game_sessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalSchema: "public",
                        principalTable: "game_sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_game_logs_players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "public",
                        principalTable: "players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "game_players",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: false),
                    JoinTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAlive = table.Column<bool>(type: "boolean", nullable: false),
                    VotedOutAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_game_players_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "public",
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_game_players_game_sessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalSchema: "public",
                        principalTable: "game_sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_game_players_players_PlayerId",
                        column: x => x.PlayerId,
                        principalSchema: "public",
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "votes",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GameSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoterPlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    VotedForPlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoteTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Round = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_votes_game_sessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalSchema: "public",
                        principalTable: "game_sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_votes_players_VotedForPlayerId",
                        column: x => x.VotedForPlayerId,
                        principalSchema: "public",
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_votes_players_VoterPlayerId",
                        column: x => x.VoterPlayerId,
                        principalSchema: "public",
                        principalTable: "players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_game_logs_GameSessionId",
                schema: "public",
                table: "game_logs",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_game_logs_PlayerId",
                schema: "public",
                table: "game_logs",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_game_players_CharacterId",
                schema: "public",
                table: "game_players",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_game_players_GameSessionId",
                schema: "public",
                table: "game_players",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_game_players_PlayerId",
                schema: "public",
                table: "game_players",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_game_sessions_DisasterId",
                schema: "public",
                table: "game_sessions",
                column: "DisasterId");

            migrationBuilder.CreateIndex(
                name: "IX_game_sessions_HostPlayerId",
                schema: "public",
                table: "game_sessions",
                column: "HostPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_game_sessions_InviteCode",
                schema: "public",
                table: "game_sessions",
                column: "InviteCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_players_UserName",
                schema: "public",
                table: "players",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_votes_GameSessionId",
                schema: "public",
                table: "votes",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_votes_VotedForPlayerId",
                schema: "public",
                table: "votes",
                column: "VotedForPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_votes_VoterPlayerId",
                schema: "public",
                table: "votes",
                column: "VoterPlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_logs",
                schema: "public");

            migrationBuilder.DropTable(
                name: "game_players",
                schema: "public");

            migrationBuilder.DropTable(
                name: "votes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "characters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "game_sessions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "disasters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "players",
                schema: "public");
        }
    }
}
