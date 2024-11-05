import React from 'react';
import fotoGustavo from '../../assets/image/foto_gustavo.webp'
import './Index.css'

function SendSomething({ placeholder }) {
    return (
        <section className='enviarArtigo'>
            <div className='componentIsolator-1'>
                <img className='fotoArtigo' src={fotoGustavo} />
            </div>
            <div className='componentIsolator-1'>
                <button className='botaoEnviarArtigo'>{placeholder}</button>
            </div>
        </section>
    );
}

export default SendSomething;