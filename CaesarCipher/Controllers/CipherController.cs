using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaesarCipher.Models;

namespace CaesarCipher.Controllers
{
    public class CipherController : Controller
    {
        // GET: /Cipher/
        public ActionResult Index()
       {
            Cipher defaultCipher = new Cipher();
            return View(defaultCipher);
       }

        // POST: /Cipher/
        [HttpPost]
        public ActionResult Index(string txt, int shift, string encrypt)
       {
            Cipher cipher = new Cipher();
            cipher.Text = txt;
            cipher.Shift = shift;
            switch(encrypt)
            {
                case "Encrypt":
                    cipher.IsDecrypt = false;
                    break;
                case "Decrypt":
                    cipher.IsDecrypt = true;
                    break;
            }
            cipher.Encrypt();

            return View(cipher);
       }
    }
}