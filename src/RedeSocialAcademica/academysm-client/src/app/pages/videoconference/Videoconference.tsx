import { useCallback, useEffect, useState } from "react";
import VideoConferenceApplicationServices from "../../services/videoConferenceApplicationServices";
import DailyIFrame, { DailyCall } from '@daily-co/daily-js'
import { DailyAudio, DailyProvider } from "@daily-co/daily-react";
import HairCheck from "../../components/dailyComponents/hairCheck/hairCheck";
import Call from "../../components/dailyComponents/call/call";
import Tray from "../../components/dailyComponents/tray/tray";
import HomeScreen from "../../components/dailyComponents/homeScreen/homeScreen";
import NavbarWhite from '../../components/navbarWhite/Index.jsx'
import './Videoconference.css'
import navigateTo from "../../../infra/navigation/navigation.js";

const STATE_IDLE = 'STATE_IDLE';
const STATE_CREATING = 'STATE_CREATING';
const STATE_JOINING = 'STATE_JOINING';
const STATE_JOINED = 'STATE_JOINED';
const STATE_LEAVING = 'STATE_LEAVING';
const STATE_ERROR = 'STATE_ERROR';
const STATE_HAIRCHECK = 'STATE_HAIRCHECK';

const Services: VideoConferenceApplicationServices = new VideoConferenceApplicationServices()

export default function Videoconference() {
    const [appState, setAppState] = useState<string>(STATE_IDLE)
    const [roomUrl, setRoomUrl] = useState<string | null>(null)
    const [callObject, setCallObject] = useState<DailyCall | null>(null)
    const [apiError, setApiError] = useState<boolean>(false)

    const pathParts: Array<string> = window.location.pathname.split('/')
    const groupId: string = pathParts[pathParts.length - 1]    

    const createCall: () => Promise<any> = useCallback(async () => {
        setAppState(STATE_CREATING)

        try {
            const isTeacher: boolean = await Services.isProfessorAccessing(groupId)

            if (isTeacher === true) {
                try {
                    const roomUrl: string = await Services.createVideoConference(groupId)
                    return roomUrl
                } catch (error) {
                    console.error('Error creating room', error);
                    setRoomUrl(null);
                    setAppState(STATE_IDLE);
                    setApiError(true);
                    return null;  // Retorna null em caso de erro para garantir que um valor seja sempre retornado
                }
            } else {
                try {
                    const url: string = await Services.getVideoConferenceUrl(groupId)
                    return url
                } catch (error: any) {
                    console.error('Erro ao Acessar a URL da Vídeoconferência', error)
                    setRoomUrl(null)

                    alert('Não Há Nenhuma Vídeoconferência Ocorrendo no Momento.')
                    navigateTo(`/Grupos/Home/${groupId}`)

                    return null
                }
            }
        } catch (erroGlobal) {
            console.log('Erro ao Determinar se o Usuário é um Professor', erroGlobal)

            setAppState(STATE_IDLE)
            setApiError(true)

            return null
        }
    }
        , [groupId])

    const startHairCheck = useCallback(async (url: string) => {
        const newCallObject: DailyCall = DailyIFrame.createCallObject()

        setRoomUrl(url)
        setCallObject(newCallObject)
        setAppState(STATE_HAIRCHECK)

        await newCallObject.preAuth({ url })
        await newCallObject.startCamera()
    }, []) 

    const joinCall = useCallback((username: string) => {
        callObject?.join({ url: roomUrl ? roomUrl : undefined, userName: username });
    }, [callObject, roomUrl])

    const startLeavingCall = useCallback(() => {
        if (!callObject) return

        if (appState === STATE_ERROR) {
            callObject.destroy().then(() => {
                setRoomUrl(null)
                setCallObject(null)
                setAppState(STATE_IDLE)
            })
        } else {
            setAppState(STATE_LEAVING)
            callObject.leave()
        }
    }, [callObject, appState])

    useEffect(() => {
        const url = Services.roomUrlFromPageUrl()

        if (url) {
            startHairCheck(url)
        }
    }, [startHairCheck])

    useEffect(() => {
        const pageUrl = Services.pageUrlFromRoomUrl(roomUrl!)

        if (pageUrl === window.location.href) return

        window.history.replaceState(null, '', pageUrl)
    }, [roomUrl])

    useEffect(() => {
        if (!callObject) return

        const events: Array<'joined-meeting' | 'left-meeting' | 'error' | 'camera-error'> = 
            ['joined-meeting', 'left-meeting', 'error', 'camera-error'];

        function handleNewMeetingState(): void {
            switch (callObject?.meetingState()) {
                case 'joined-meeting':
                    setAppState(STATE_JOINED)
                    break
                case 'left-meeting':
                    callObject.destroy().then(() => {
                        setRoomUrl(null)
                        setCallObject(null)
                        setAppState(STATE_IDLE)
                    })
                    break
                case 'error':
                    setAppState(STATE_ERROR)
                    break
                default:
                    break
            }
        }

        handleNewMeetingState()

        events.forEach((event) => {
            callObject?.on(event, handleNewMeetingState);
        });

        return () => {
            events.forEach((event) => callObject.off(event, handleNewMeetingState));
        };
    }, [callObject])

    const showCall: boolean = !apiError && [STATE_JOINING, STATE_JOINED, STATE_ERROR].includes(appState)

    const showHairCheck = !apiError && appState === STATE_HAIRCHECK

    const Render = () => {
        if (apiError) {
            return (
                <div className='api-error'>
                    <h1>Erro</h1>
                    <p>A sala não pôde ser criada.</p>
                    <a href="https://github.com/daily-demos/custom-video-daily-react-hooks#readme">
                        readme
                    </a>
                </div>
            )
        }

        console.log(callObject)

        if (showHairCheck || showCall) {
            return (
                <DailyProvider callObject={callObject}>
                    {showHairCheck ? (
                        <HairCheck joinCall={joinCall} cancelCall={startLeavingCall} />
                    ) :
                    (
                        <>
                                <Call />
                                <Tray leaveCall={startLeavingCall} />
                                <DailyAudio />
                        </>
                    )            
                    }
                </DailyProvider>
            )
        }

        return <HomeScreen createCall={createCall} startHairCheck={startHairCheck} />
    }

    return (
        <div className='app'>
            <NavbarWhite />
            <Render />
        </div>
    )
}