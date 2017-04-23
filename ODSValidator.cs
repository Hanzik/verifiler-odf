using System;
using AODL.Document.SpreadsheetDocuments;
using VerifilerCore;

namespace VerifilerODF {
	/// <summary>
	/// This validation step is using the AODL library using the OpenOffice API.
	/// 
	/// The error code produced by this validation is Error.Corrupted.
	/// </summary>
	public class ODSValidator : FormatSpecificValidator {

		public override int ErrorCode { get; set; } = Error.Corrupted;

		public override void Setup() {
			Name = "OpenDocument sheet files verification";
			RelevantExtensions.Add(".ods");
			Enable();
		}

		public override void ValidateFile(string file) {
			try {
				SpreadsheetDocument document = new SpreadsheetDocument();
				document.Load(file);
			} catch (Exception e) {
				ReportAsError("File is corrupted: " + file + "; Message: " + e.Message);
				GC.Collect();
			}
		}
	}
}