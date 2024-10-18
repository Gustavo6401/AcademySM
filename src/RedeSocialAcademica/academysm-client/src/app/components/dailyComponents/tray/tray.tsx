import { DailyCall } from "@daily-co/daily-js";
import { useAppMessage, useAudioTrack, useDaily, useLocalSessionId, useScreenShare, useVideoTrack } from "@daily-co/daily-react";
import { MediaTrackState } from "@daily-co/daily-react/dist/hooks/useMediaTrack";
import { useCallback, useState } from "react";
import MeetingInformation from "../meetingInformation/meetingInformation";
import Chat from "../chat/chat";
import { CameraOff, CameraOn, ChatHighlighted, ChatIcon, Info, Leave, MicrophoneOff, MicrophoneOn, Screenshare } from '../icons/icons.jsx'

interface TrayProperties {
    leaveCall: () => void
}

const Tray: React.FC<TrayProperties> = ({ leaveCall }) => {
    const callObject: DailyCall | null = useDaily()
    const { isSharingScreen, startScreenShare, stopScreenShare } = useScreenShare()

    const [showMeetingInformation, setShowMeetingInformation] = useState<boolean>(false)
    const [showChat, setShowChat] = useState<boolean>(false)
    const [newChatMessage, setNewChatMessage] = useState<boolean>(false)

    const localSessionId: string = useLocalSessionId()
    const localVideo: MediaTrackState = useVideoTrack(localSessionId)
    const localAudio: MediaTrackState = useAudioTrack(localSessionId)
    const mutedVideo: boolean = localVideo.isOff
    const mutedAudio: boolean = localAudio.isOff

    useAppMessage({
        onAppMessage: useCallback(() => {
            if (!showChat) {
                setNewChatMessage(true)
            }
        }, [showChat])
    })

    const toggleVideo: () => void = useCallback(() => {
        callObject?.setLocalVideo(mutedVideo)
    }, [callObject, mutedVideo])

    const toggleAudio: () => void = useCallback(() => {
        callObject?.setLocalAudio(mutedAudio)
    }, [callObject, mutedAudio])

    const toggleShareScreen = () => isSharingScreen ? stopScreenShare() : startScreenShare()

    const toggleMeetingInformation: () => void = () => {
        setShowMeetingInformation(!showMeetingInformation)
    }

    const toggleChat: () => void = () => {
        setShowChat(!showChat)

        if (newChatMessage) {
            setNewChatMessage(!newChatMessage)
        }
    }

    return (
        <div className='tray'>
            {showMeetingInformation && <MeetingInformation />}
            <Chat showChat={showChat} toggleChat={toggleChat} />
            <div className='tray-buttons-container'>
                <div className='controls'>
                    <button onClick={toggleVideo} type='button'>
                        {mutedVideo ? <CameraOff /> : <CameraOn />}
                        {mutedVideo ? 'Ligar Câmera' : 'Desligar Câmera'}
                    </button>
                    <button onClick={toggleAudio} type='button'>
                        {mutedAudio ? <MicrophoneOff /> : <MicrophoneOn />}
                        {mutedAudio ? 'Ligar Microfone' : 'Desligar Microfone'}
                    </button>
                </div>
                <div className='actions'>
                    <button onClick={toggleShareScreen} type='button'>
                        <Screenshare />
                        {isSharingScreen ? 'Parar de Compartilhar a Tela' : 'Compartilhar a Tela'}
                    </button>
                    <button onClick={toggleMeetingInformation} type='button'>
                        <Info />
                        {showMeetingInformation ? 'Esconder Informações' : 'Mostrar Informações'}
                    </button>
                    <button onClick={toggleChat} type='button'>
                        {newChatMessage ? <ChatHighlighted /> : <ChatIcon />}
                        {showChat ? 'Esconder Chat' : 'Mostrar Chat'}
                    </button>
                </div>
                <div className='leave'>
                    <button onClick={leaveCall} type='button'>
                        <Leave />
                    </button>
                </div>
            </div>
        </div>
    )
}

export default Tray