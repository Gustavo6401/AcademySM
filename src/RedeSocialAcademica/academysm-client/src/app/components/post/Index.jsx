import React from 'react';
import './Index.css'

/**
 * 
 * @param {string} title
 * @param {string} text
 * @param {string[]} images
 * @returns
 */
export default function Post({ title, text, images }) {
    return (
        <section className='post'>
            <h1 className='post-title'>{title}</h1>
            <p className='post-text'>{text}</p>
            <div className='postCarousel'>
                {images.map(item =>
                    <img src={item} className='post-image' />)
                }
            </div>
        </section>
    );
}