import { useAppMessage, useLocalSessionId, useParticipantProperty } from "@daily-co/daily-react";
import { useCallback, useState } from "react";
import { Arrow } from '../icons/icons.jsx'

interface ChatProperties {
    showChat: boolean
    toggleChat: () => void
}

const Chat: React.FC<ChatProperties> = ({ showChat, toggleChat }) => {
    const [messages, setMessages] = useState<Array<any>>(new Array())
    const [inputValue, setInputValue] = useState<string>('')
    const localSessionId: string = useLocalSessionId()
    const username: string = useParticipantProperty(localSessionId, 'user_name')

    const sendAppMessage = useAppMessage({
        onAppMessage: useCallback(
            (ev) =>
                setMessages((existingMessages) => [
                    ...existingMessages,
                    {
                        msg: ev.data.msg,
                        name: ev.data.name
                    },
                ]),
            [],
        )
    })

    const sendMessage = useCallback(
        (message: string) => {
            sendAppMessage(
                {
                    msg: message,
                    name: username || 'Convidado'
                },
                '*'
            ),
                setMessages([
                    ...messages,
                    {
                        msg: message,
                        name: username || 'Convidado'
                    }
                ])
        },
        [messages, sendAppMessage, username]
    )

    const handleChange = (e: React.FormEvent<HTMLInputElement>) => {
        setInputValue(e.currentTarget.value)
    }

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()

        if (!inputValue.trim()) return

        sendMessage(inputValue)
        setInputValue('')
    }

    return showChat ? (
        <aside>
            <button onClick={toggleChat} className='close-chat' type='button'>Fechar Chat</button>
            <ul className='chat-messages'>
                {messages.map((message, index) => (
                    <li key={`message-${index}`} className="chat-message">
                        <span className="chat-message-author">{message?.name}</span>:{' '}
                        <p className="chat-message-body">{message?.msg}</p>
                    </li>
                ))}
            </ul>
            <div className='add-message'>
                <form className='chat-form' onSubmit={handleSubmit}>
                    <input className='chat-input' type='text' placeholder='Digite Aqui Sua Mensagem' value={inputValue} onChange={handleChange} />
                    <button type='submit' className='chat-submit-button'>
                        <Arrow />
                    </button>
                </form>
            </div>
        </aside>
    ) : null
}

export default Chat