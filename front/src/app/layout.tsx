import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "ConjurinG",
  description: "Web Site about Conjuring family",
};

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode }>) {
  return (
    <html lang="pt">
      <body className={inter.className}>
        {/* <header className="flex justify-between items-center p-5 bg-header">
          <div>
            <a href="" className="text-txt">
              Inicío
            </a>
          </div>
          <div className="flex gap-5 items-center">
            <a href="" className="text-txt">
              Blog
            </a>
            <a href="" className="text-txt">
              Galeria
            </a>
            <a href="" className="text-txt">
              Parcerias
            </a>
          </div>
        </header> */}
        <section className="min-h-screen bg-main">
          {children}
        </section>
        {/* <footer className="flex flex-col justify-around p-10 bg-footer">
          <div>
            <div>
              links uteis
            </div>
            <div>
              direitos reservados e afins
            </div>
          </div>
          <div>
            Criado por Yasuo_ConjurinG
          </div>
        </footer> */}
      </body>
    </html>
  );
}
