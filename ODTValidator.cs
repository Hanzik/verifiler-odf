using System;
using AODL.Document.TextDocuments;
using VerifilerCore;

namespace VerifilerODF {

	/// <summary>
	/// This validation step is using the AODL library using the OpenOffice API.
	/// 
	/// The error code produced by this validation is Error.Corrupted.
	/// </summary>
	public class ODTValidator : FormatSpecificValidator {

		public override int ErrorCode { get; set; } = Error.Corrupted;

		public override void Setup() {
			Name = "OpenDocument text files verification";
			RelevantExtensions.Add(".odt");
			Enable();
		}

		public override void ValidateFile(string file) {
			try {
				TextDocument document = new TextDocument();
				document.Load(file);
			} catch (Exception e) {
				ReportAsError("File is corrupted: " + file + "; Message: " + e.Message);
				GC.Collect();
			}
		}
	}
}