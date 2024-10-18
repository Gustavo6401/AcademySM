import './userMediaError.css'

function refreshPage() {
    console.log('Certifique-se de Ter Acesso à Câmera nas suas configurações.')
    window.location.reload()
}

export default function UserMediaError() {
    return (
        <div className='call'>
            <div className='info-box get-user-media-error'>
                <h1>Câmera ou Microfone Bloqueados</h1>
                <button onClick={refreshPage} type='button'>Tente Novamente</button>
                <p><a href='https://docs.daily.co/guides/how-daily-works/handling-device-permissions' target='_blank' rel='noreferrer'>Ajuda</a></p>
            </div>
        </div>
    )
}