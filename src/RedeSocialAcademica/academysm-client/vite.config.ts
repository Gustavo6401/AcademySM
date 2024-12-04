import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react';
import fs from 'fs'
import path from 'path'

const keyPath = path.resolve(__dirname, 'key.pem')
const certPath = path.resolve(__dirname, 'cert.pem')

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [react()],
    resolve: {
        extensions: ['.js', '.ts', '.tsx', '.jsx']
    },
    server: {
        https: {
            key: fs.readFileSync(keyPath),
            cert: fs.readFileSync(certPath)
        },
        port: 5173,
        host: 'localhost'
    }
})
