import React from 'react';
import './Index.css'
import fotoGustavo from '../../assets/image/foto_gustavo.webp'

function Question({ questionTitle, questionDescription, questionMakerName }) {
    let colorComponent = ''

    if (questionDescription === 'Respondida') {
        colorComponent = 'questionButton verde'
    }
    else {
        colorComponent = 'questionButton vermelho'
    }

    return (
        <div className='questionComponent'>
            <div className={colorComponent}>
                <i className='bi bi-question-lg'></i>
            </div>
            <div className='questionContent'>
                <h3 className='questionTitle'>{questionTitle}</h3>
                <h4 className='questionDescription'>{questionDescription}</h4>
                <div className='questionMaker'>
                    <img className='questionMakerProfilePic' src={fotoGustavo} />
                    <h5 className='questionDescription bold'>{questionMakerName}</h5>
                </div>
            </div>
        </div>
    );
}

export default Question;