import { DailyVideo, StatefulDevice, useDaily, useDailyEvent, useDevices, useLocalSessionId, useParticipantProperty } from '@daily-co/daily-react'
import './hairCheck.css'
import { DailyCall } from '@daily-co/daily-js'
import { useCallback, useEffect, useState } from 'react'
import UserMediaError from '../userMediaError/userMediaError.jsx'

interface HairCheckProperties {
    joinCall: (username: string) => void
    cancelCall: () => void
}

const HairCheck: React.FC<HairCheckProperties> = ({ joinCall, cancelCall }) => {
    const localSessionId: string = useLocalSessionId()

    const initialUserName: string = useParticipantProperty(localSessionId, 'user_name')
    const { currentCam, currentMic, currentSpeaker, microphones, speakers, cameras, setMicrophone, setCamera, setSpeaker } = useDevices()
    const callObject: DailyCall | null = useDaily()

    const [username, setUsername] = useState<string>(initialUserName)

    const [getUserMediaError, setGetUserMediaError] = useState<boolean>(false)

    useEffect(() => {
        setUsername(initialUserName)
    }, [initialUserName])

    useEffect(() => {
        navigator.mediaDevices.enumerateDevices().then((devices) => {
            devices.forEach((device) => {
                console.log(`${device.kind}: ${device.label} id = ${device.deviceId}`)
            })
        })
    }, [])

    useDailyEvent(
        'camera-error',
        useCallback(() => {
            setGetUserMediaError(true)
        }, [])
    )

    const handleChange = (e: React.FormEvent<HTMLInputElement>) => {
        setUsername(e.currentTarget.value)
        callObject?.setUserName(e.currentTarget.value)
    }

    const handleJoin = (e: React.FormEvent) => {
        e.preventDefault()
        joinCall(username.trim())
    }

    const updateMicrophone = (e: React.FormEvent<HTMLSelectElement>) => {
        setMicrophone(e.currentTarget.value)
    }

    const updateSpeakers = (e: React.FormEvent<HTMLSelectElement>) => {
        setSpeaker(e.currentTarget.value)
    }

    const updateCamera = (e: React.FormEvent<HTMLSelectElement>) => {
        setCamera(e.currentTarget.value)
    }

    return getUserMediaError ? (
        <UserMediaError />
    ) : (
        <form className='hair-check' onSubmit={handleJoin}>
                <h1>Escolha Seu Hardware</h1>
                {localSessionId && <DailyVideo sessionId={localSessionId} mirror type={'video'} />}
                <div>
                    <label htmlFor='username'>Seu Nome:</label>
                    <input name='username' type='text' placeholder='Insira Seu Nome de Usuário' onChange={handleChange} value={username || ''} />
                </div>
                <div>
                    <label className='micOptions'>Microfone:</label>
                    <select name='micOptions' id='micSelect' onChange={updateMicrophone} value={currentMic?.device.deviceId}>
                        {microphones.map((mic: StatefulDevice) => (
                            <option key={`mic-${mic.device.deviceId}`} value={mic.device.deviceId}>
                                {mic.device.label}
                            </option>
                        ))}
                    </select>                    
                </div>
                <div>
                    <label className='speakersOptions'>Alto-Falante:</label>
                    <select name='speakersOptions' id='sepakersSelect' onChange={updateSpeakers} value={currentSpeaker?.device.deviceId}>
                        {microphones.map((speaker: StatefulDevice) => (
                            <option key={`speaker-${speaker.device.deviceId}`} value={speaker.device.deviceId}>
                                {speaker.device.label}
                            </option>
                        ))}
                    </select>
                </div>
                <div>
                    <label className='cameraOptions'>Câmera</label>
                    <select name='cameraOptions' id='cameraSelect' onChange={updateCamera} value={currentCam?.device.deviceId}>
                        {microphones.map((camera: StatefulDevice) => (
                            <option key={`cam-${camera.device.deviceId}`} value={camera.device.deviceId}>
                                {camera.device.label}
                            </option>
                        ))}
                    </select>
                </div>
                <button onClick={handleJoin} type='submit'>
                    Juntar-se à chamada
                </button>
                <button onClick={cancelCall} className='cancel-call' type='button'>
                    Voltar para o Início
                </button>
        </form>
    )
}

export default HairCheck