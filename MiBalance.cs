using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
internal static class MiBalance {
 [STAThread] static void Main() {
  string page = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "index.html");
  if (!File.Exists(page)) { MessageBox.Show("No se encontró index.html junto a Mi balance.exe. Conserva ambos archivos en la misma carpeta.", "Mi balance", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
  string[] browsers = {
   Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Microsoft\Edge\Application\msedge.exe"),
   Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Microsoft\Edge\Application\msedge.exe")
  };
  foreach (string browser in browsers) {
   if (!File.Exists(browser)) continue;
   try { Process.Start(new ProcessStartInfo(browser, "--app=\"" + new Uri(page).AbsoluteUri + "\"") { UseShellExecute = true }); return; }
   catch (Exception ex) { MessageBox.Show("No se pudo abrir Mi balance: " + ex.Message, "Mi balance", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
  }
  MessageBox.Show("Mi balance necesita Microsoft Edge instalado para mostrar su ventana.", "Mi balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
 }
}
