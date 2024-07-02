import React from 'react'
import axiosInstance from '../api/axiosConfig';
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { z } from "zod"

import { Button } from "../@/components/ui/button"
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "../@/components/ui/form"
import { Input } from "../@/components/ui/input"
import { useAuth } from '../Auth/AuthProvider';



const LoginPage = () => {
  const formSchema = z.object({
    email: z.string().email(),
    password: z.string().min(2),
  });

  const { login } = useAuth();

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema)
  })

  const onSubmit = async (data) => {
    try {
      login(data.email, data.password);
      // Handle success or redirect
    } catch (error) {
      console.error('Error signing in:', error);
      // Handle error
    }
  };

  return (
    <>
      <div className="flex flex-col justify-center items-center h-screen">
        <div className="text-center">
          <h1 className="text-3xl font-bold mb-4">Login</h1>
        </div>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8 w-full max-w-sm">
            <FormField
              control={form.control}
              name="email"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Username</FormLabel>
                  <FormControl>
                    <Input placeholder="email" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="password"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Password</FormLabel>
                  <FormControl>
                    <Input type="password" placeholder="password" {...field} />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <div className="flex justify-center p-4">
              <Button type="submit" className="w-full sm:w-auto">Submit</Button>
            </div>
          </form>
        </Form>
      </div>
    </>
  );
};


export default LoginPage