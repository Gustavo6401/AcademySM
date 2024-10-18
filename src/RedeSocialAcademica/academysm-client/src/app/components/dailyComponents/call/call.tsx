import { DailyVideo, useDailyEvent, useLocalSessionId, useParticipantIds, useScreenShare } from "@daily-co/daily-react";
import UserMediaError from '../userMediaError/userMediaError.jsx'
import { useCallback, useState } from "react";
import Tile from "../tile/tile";
import './call.css'

export default function Call(): React.JSX.Element {
    const [getUserMediaError, setGetUserMediaError] = useState<Boolean>(false)

    useDailyEvent('camera-error', useCallback(() => {
                setGetUserMediaError(true)
            }, []
        )
    )

    const { screens } = useScreenShare()
    const remoteParticipantIds: Array<string> = useParticipantIds({ filter: 'remote' })

    const localSessionId: string = useLocalSessionId()
    const isAlone: boolean = remoteParticipantIds.length < 1 || screens.length < 1

    const renderCallScreen = () => {
        return (
            <div className={screens.length > 0 ? 'is-screenshare' : 'call'}>
                {localSessionId && (<DailyVideo automirror sessionId={localSessionId} type={'video'} />)}
                {remoteParticipantIds.length > 0 || screens.length > 0 ? (
                    <div>
                        {remoteParticipantIds.map((id) => (
                            <Tile id={id} isAlone isLocal isScreenShare mirror={false} />
                        ))}
                        {screens.map((screen) => (
                            <Tile id={screen.session_id} isScreenShare={true} isAlone isLocal mirror={false} />
                        ))}
                    </div>
                ) : (
                    <div className='info-box'>
                        <h1>Esperando os Outros</h1>
                        <p>Convide Por meio desse Link:</p>
                        <span className='room-url'>{window.location.href}</span>
                    </div>
                )}
            </div>
        )
    }

    return getUserMediaError ? <UserMediaError /> : renderCallScreen()
}