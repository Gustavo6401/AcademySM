import React from 'react';

/**
 * 
 * @param {number} numberVotes
 * @returns
 */
export default function LargeVotes({ numberVotes }) {
    return (
        <div className='duvidaVotes'>
            <div className='duvidaVoteButton'>
                <i className='bi bi-caret-up-fill'></i>
            </div>
            <label>{numberVotes}</label>
            <div className='duvidaVoteButton'>
                <i className='bi bi-caret-down-fill'></i>
            </div>
        </div>
    );
}