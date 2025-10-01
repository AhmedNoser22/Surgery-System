using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Surgery_System.Migrations
{
    /// <inheritdoc />
    public partial class inyt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "MedicalDevices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "MedicalDevices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "MedicalDevices",
                columns: new[] { "Id", "Description", "Icon", "Name", "SerialNumber" },
                values: new object[,]
                {
                    { 1, "Provides anesthesia to patients.", "anesthesia-icon.png", "Anesthesia Machine", "AN-2025-001" },
                    { 2, "Adjustable table for operations.", "surgical-table-icon.png", "Surgical Table", "ST-2025-002" },
                    { 3, "Supports heart and lung functions.", "heart-lung-icon.png", "Heart-Lung Machine", "HL-2025-003" },
                    { 4, "Magnetic resonance imaging device.", "mri-icon.png", "MRI Scanner", "MRI-2025-004" },
                    { 5, "For bone surgeries.", "Orthopedic-drill-icon.png", "Orthopedic Drill", "OD-2025-005" },
                    { 6, " For internal organ viewing.", "endoscope-icon.png", "Endoscope", "EN-2025-006" },
                    { 7, " Restarts or stabilizes heart rhythm.", "defibrillator-icon.png", "Defibrillator", "DF-2025-007" }
                });
        }
    }
}
