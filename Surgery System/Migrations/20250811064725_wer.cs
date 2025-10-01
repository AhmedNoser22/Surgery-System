using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Surgery_System.Migrations
{
    /// <inheritdoc />
    public partial class wer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MedicalDevices",
                columns: new[] { "Id", "Description", "Name", "SerialNumber" },
                values: new object[,]
                {
                    { 1, "Provides anesthesia to patients.", "Anesthesia Machine", "AN-2025-001" },
                    { 2, "Adjustable table for operations.", "Surgical Table", "ST-2025-002" },
                    { 3, "Supports heart and lung functions.", "Heart-Lung Machine", "HL-2025-003" },
                    { 4, "Magnetic resonance imaging device.", "MRI Scanner", "MRI-2025-004" },
                    { 5, "For bone surgeries.", "Orthopedic Drill", "OD-2025-005" },
                    { 6, "For internal organ viewing.", "Endoscope", "EN-2025-006" },
                    { 7, "Restarts or stabilizes heart rhythm.", "Defibrillator", "DF-2025-007" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalDevices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedicalDevices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedicalDevices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MedicalDevices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MedicalDevices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MedicalDevices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MedicalDevices",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
