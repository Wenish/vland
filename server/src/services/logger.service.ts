const logger = (text: string, context?: string) => {
    const currentDate = new Date()
    const timestamp = `${currentDate.getHours()}:${currentDate.getMinutes()}:${currentDate.getSeconds()}`
    console.log(`[\x1b[33m${context || 'Server'}\x1b[37m] \x1b[90m${timestamp} \x1b[37m${text}`,)
}

export default logger