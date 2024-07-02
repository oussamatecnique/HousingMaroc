import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path'
import dotenv from 'dotenv';
import replace from '@rollup/plugin-replace';

// https://vitejs.dev/config/
dotenv.config();

export default defineConfig(() => {
  const env = dotenv.config().parsed;

  return {
    plugins: [
      react(),
      replace({
        preventAssignment: true,
        'process.env.REACT_APP_API_BASE_URL': JSON.stringify(env!.REACT_APP_API_BASE_URL),
      }),
    ],
    resolve: {
      alias: {
        "@": path.resolve(__dirname, "./src"),
      },
    },
  };
});