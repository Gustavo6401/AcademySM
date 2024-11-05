import React from 'react';
import Navbar from '../../components/navbar/index'
import fotoGustavo from '../../assets/image/foto_gustavo.webp'
import AcademySMText from '../../components/academySMText/Index'
import './Index.css'
import GroupsNavbar from '../../components/groupsNavbar/Index';
import SendSomething from '../../components/sendSomething/Index';

/**
 * 
 * @param {string} filename
 */
function DownloadPdf({ filename }) {
    return (
        <div className='componentDownloadArticlePdf'>
            <div className='buttonDownloadArticlePdf'>
                <i className='bi bi-file-earmark-pdf-fill'></i>
                <label className='downloadArticleFilename'>{filename}</label>
            </div>
        </div>
    )
}

export default function Artigos() {
    return (
        <div>
            <Navbar />
            <div className='artigos'>
                <main className='artigosMainContent'>
                    <SendSomething placeholder='Enviar Artigo' />
                    <AcademySMText
                        title='Whitepaper da Academy SM'
                        text={"Autor: Gustavo da Silva Oliveira \n \n Ano da Publicação - 2024"}
                        component1={<DownloadPdf filename='WhitePaperAcademySM.pdf' />}
                    />
                </main>
                <section className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </section>
            </div>
        </div>
    );
}